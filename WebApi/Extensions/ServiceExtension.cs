using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BilgiSayarDbContext>().AddDbContext<BilgiSayarDbContext>(
            options => {
                   options.UseSqlServer(configuration.GetConnectionString("sqlconnection"), builder => builder.MigrationsAssembly("WebApi"));//Bilgi_SayarUI
                   options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                   options.EnableSensitiveDataLogging(false);
               }

               );

        }
     

    }
}
