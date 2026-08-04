
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SwagApiApp.Data;

namespace SwagApiApp.Installer
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "Swag APP", Version = "v1" });
            });

        }
    }
}
