using FoodMart.POS.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace FoodMart.POS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Logging.AddConsole();

            builder.Services.AddScoped<IMainService, MainService>();
            builder.Services.AddHostedService<HostedService>();


            var app = builder.Build();
            app.RunAsync().Wait();
        }
    }
}