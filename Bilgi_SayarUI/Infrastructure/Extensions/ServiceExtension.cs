using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Contexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bilgi_SayarUI.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BilgiSayarDbContext>().AddDbContext<BilgiSayarDbContext>(
                options => { options.UseSqlServer(configuration.GetConnectionString("sqlconnection"), builder => builder.MigrationsAssembly("Bilgi_SayarUI"));
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.EnableSensitiveDataLogging(true);
                }
            
                );
            
            
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                // Session konfigürasyonları
                options.IdleTimeout = TimeSpan.FromMinutes(30); 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IContentImageService, ContentImageManager>();
            services.AddScoped<IEntryService, EntryManager>();
            services.AddScoped<IWriterService, WriterManager>();
           
            


        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {

            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IContentImageDal, EfContentImageDal>();
            services.AddScoped<IEntryDal, EfEntryDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IWriterDal, EfWriterDal>();



        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;// endpointsler lower gösterilecek
                options.AppendTrailingSlash = false;//Sona / eklenecek mi slash
            });

        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>(options =>

            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit= false;
                options.Password.RequiredLength = 6;
            
            
            
            }).AddEntityFrameworkStores<BilgiSayarDbContext>();

        }
      

    }
}
