using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using FoodMart.POS.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace FoodMart.POS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");

            builder.Logging.AddConsole();
            
            builder.Services.AddScoped<IMainService, MainService>();
            builder.Services.AddHostedService<HostedService>();


            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlite("Data Source=Identity.db");
            });

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;

                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();


            var app = builder.Build();
            app.RunAsync().Wait();
        }
    }
}