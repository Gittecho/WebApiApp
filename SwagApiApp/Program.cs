using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SwagApiApp.Data;
using SwagApiApp.Options;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore;

namespace SwagApiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Need To minimize as ASP.NET 3-4 version

            var builder = WebApplication.CreateBuilder(args);
            var startupHandler = new Startup(builder.Configuration);

            startupHandler.ConfigurationServices(builder.Services);
            var app = builder.Build();
            startupHandler.Configure(app);
            
            app.Run();
        }
    }
}
