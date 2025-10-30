using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyPortfolio
{
    // Bu sınıf, Program.cs'te hizmet sağlayıcısından (service provider) 
    // IHttpContextAccessor'ı statik olarak kaydetmek için kullanılır.
    public static class ApplicationActivator
    {
        // IHttpContextAccessor'ı statik alanda tutuyoruz.
        private static IHttpContextAccessor _httpContextAccessor;

        // Servis sağlayıcısından HttpContextAccessor'ı alıp statik alana atayan metot.
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Hangfire filtresinde kullanacağımız basit erişim noktası.
        public static HttpContext Current
        {
            get
            {
                return _httpContextAccessor?.HttpContext;
            }
        }
    }
}