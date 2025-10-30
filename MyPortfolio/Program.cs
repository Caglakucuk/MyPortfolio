using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using BusinessLayer.Abstract;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyPortfolio; // Varsayımsal Service arayüzleriniz için

var builder = WebApplication.CreateBuilder(args);

// --- Environment üzerinden DB bağlantısı ---
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("DATABASE_URL environment variable is not set.");
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// --- DbContext Kaydı ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
    {
        opts.LoginPath = "/Login/Index"; 
        opts.AccessDeniedPath = "/Error/AccessDenied"; 
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
    });

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {    
        options.ModelValidatorProviders.Clear(); 
    });

// --- BAĞIMLILIK ENJEKSİYONU (DEPENDENCY INJECTION) KAYITLARI ---
builder.Services.AddScoped<IHomePageDal, EfHomePageDal>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IExperienceDal, EfExperienceDal>();
builder.Services.AddScoped<ISkillsDal, EfSkillsDal>();
builder.Services.AddScoped<IProjectsDal,EfProjectsDal>();
builder.Services.AddScoped<ISertificateDal, EfSertificateDal>();
builder.Services.AddScoped<IMessagesDal, EfMessagesDal>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<EmailSenderService>();

builder.Services.Configure<EntityLayer.Common.SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings")
);

// BusinessLayer
builder.Services.AddScoped<HomePageManager>(); 
builder.Services.AddScoped<AboutManager>();
builder.Services.AddScoped<ExperienceManager>();
builder.Services.AddScoped<SkillsManager>();
builder.Services.AddScoped<ProjectsManager>();
builder.Services.AddScoped<SertificateManager>();
builder.Services.AddScoped<MessagesManager>();
builder.Services.AddScoped<SocialMediaManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// --- Hangfire ---
builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UsePostgreSqlStorage(connectionString, // <- burası artık environment variable
        new PostgreSqlStorageOptions
        {
            SchemaName = "hangfire",
        });
});
builder.Services.AddHangfireServer();

var app = builder.Build();
ApplicationActivator.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    Authorization = new [] 
    { 
        new MyPortfolio.Filters.HangfireDashboardAuthorizationFilter() 
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
