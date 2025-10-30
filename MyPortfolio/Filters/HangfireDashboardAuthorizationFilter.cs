using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Filters
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Basit statik erişim ile HttpContext'i alıyoruz.
            var httpContext = ApplicationActivator.Current; 

            if (httpContext == null || !httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            
            return true; 
        }
    }
}