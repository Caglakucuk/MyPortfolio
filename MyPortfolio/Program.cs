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

var railwayUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
string connectionString;

if (!string.IsNullOrEmpty(railwayUrl))
{
    // Railway'in URL formatını (postgres://...) standart Npgsql formatına çeviriyoruz.
    var uri = new Uri(railwayUrl);
    
    // Güvenli bağlantı ayarlarını ekliyoruz: SSL Mode=Require
    connectionString = $"Host={uri.Host};Port={uri.Port};Username={uri.UserInfo.Split(':')[0]};Password={uri.UserInfo.Split(':')[1]};Database={uri.PathAndQuery.Substring(1)};Pooling=true;SSL Mode=Require;Trust Server Certificate=true";
}
else
{
    // DATABASE_URL tanımlı değilse (yerelde çalışıyorsak), appsettings.json'dan oku.
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
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
        // [Authorize] etiketi olan bir sayfaya giriş yapılmamışsa bu sayfaya yönlendirilir.
        opts.LoginPath = "/Login/Index"; 
        
        // Opsiyonel: Erişim izni olmayan yer için (rol yetkisi yoksa)
        opts.AccessDeniedPath = "/Error/AccessDenied"; 
        
        // Oturum süresi
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
    });

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {    options.ModelValidatorProviders.Clear(); 
    });

// --- BAĞIMLILIK ENJEKSİYONU (DEPENDENCY INJECTION) KAYITLARI ---

// NOT: Bu kayıtlar, View Component'inizin (HomePageList) constructor'ında 
// talep ettiği bağımlılıkların otomatik olarak çözülmesini sağlar.

// 1. DataAccessLayer (Repository/DAL) Kayıtları:
// Bir IHomePageDal istendiğinde, AppDbContext'i constructor'da alan EfHomePageDal oluşturulur.
// GenericRepository'niz AppDbContext aldığı için bu kayıt zorunludur.
builder.Services.AddScoped<IHomePageDal, EfHomePageDal>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IExperienceDal, EfExperienceDal>();
builder.Services.AddScoped<ISkillsDal, EfSkillsDal>();
builder.Services.AddScoped<IProjectsDal,EfProjectsDal>();
builder.Services.AddScoped<ISertificateDal, EfSertificateDal>();
builder.Services.AddScoped<IMessagesDal, EfMessagesDal>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<EmailSenderService>();
// Diğer Entity'ler için de benzer kayıtları eklemeyi unutmayın:
// builder.Services.AddScoped<IAboutDal, EfAboutDal>();
// builder.Services.AddScoped<IContactDal, EfContactDal>();
// ...
builder.Services.Configure<EntityLayer.Common.SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings")
);

// 2. BusinessLayer (Manager/Service) Kayıtları:

// HomePageManager'ı direkt olarak kaydetme (View Component'inizde HomePageManager kullandığınız için)
builder.Services.AddScoped<HomePageManager>(); 
builder.Services.AddScoped<AboutManager>();
builder.Services.AddScoped<ExperienceManager>();
builder.Services.AddScoped<SkillsManager>();
builder.Services.AddScoped<ProjectsManager>();
builder.Services.AddScoped<SertificateManager>();
builder.Services.AddScoped<MessagesManager>();
builder.Services.AddScoped<SocialMediaManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// VEYA (Daha temiz ve esnek olan önerilen yöntem):
// Eğer BusinessLayer'da IHomePageService adında bir arayüzünüz varsa, 
// o arayüz üzerinden kaydetmek daha iyidir.
// builder.Services.AddScoped<IHomePageService, HomePageManager>();

// Diğer Manager/Service sınıflarınız için de benzer kayıtları ekleyin:
// builder.Services.AddScoped<ProductManager>();
// (Veya arayüz üzerinden: builder.Services.AddScoped<IProductService, ProductManager>();)
// ...
builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UsePostgreSqlStorage(connectionString, // YENİ: Otomatik seçilen bağlantı dizesini kullanıyoruz
        new PostgreSqlStorageOptions
        {
            SchemaName = "hangfire",
            PrepareSchemaIfNecessary = true
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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