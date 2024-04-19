using BusinessLogic.Abstract;
using DataAccess.Contexts;
using Entities.ErrorModels.Details;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bilgi_SayarUI.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app) 
        {
            BilgiSayarDbContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<BilgiSayarDbContext>();
           
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }


        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR").AddSupportedUICultures("tr-TR").SetDefaultCulture("tr-TR");


            });

        }

        public static void ConfigureLoggerService(this WebApplication app, ILoggerService logger)
        {
            
            app.UseExceptionHandler(appErr =>
            {
                appErr.Run(async context =>
                {

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {

                        context.Response.StatusCode = contextFeature.Error switch
                        {

                            NotFoundException => StatusCodes.Status404NotFound,
                            EmptyData => StatusCodes.Status204NoContent,
                            _ => StatusCodes.Status500InternalServerError
                           


                        };


                        logger.LogError($"Ters Gitti {contextFeature.Error}");
                        await context.Response.WriteAsync(
                            new ErrorDetail()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message

                            }.ToString());
                    }

                });

            });
        }
        public static async void ConfugireDefaultAdmin(this IApplicationBuilder app)
        {

            {
                const string adminUser = "Admin";
                const string adminPassword = "Admin+123456";

                // UserManager
                UserManager<IdentityUser> userManager = app
                    .ApplicationServices
                    .CreateScope()
                    .ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>(); // Kullanıcı eklemek için

                // RoleManager
                RoleManager<IdentityRole> roleManager = app
                    .ApplicationServices
                    .CreateAsyncScope()
                    .ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>(); //role eklemek için

                IdentityUser user = await userManager.FindByNameAsync(adminUser); // varmı böyle bir isim
                if (user is null)// yoksa ekle
                {
                    user = new IdentityUser()
                    {
                        Email = "sercan_ctn@hotmail.com",
                        PhoneNumber = "5352590377",
                        UserName = adminUser,
                    };

                    var result = await userManager.CreateAsync(user, adminPassword);

                    if (!result.Succeeded)
                        throw new Exception("Admin user could not been created.");

                    var roleResult = await userManager.AddToRolesAsync(user, //rol ekle
                        roleManager
                            .Roles
                            .Select(r => r.Name)
                            .ToList()
                    );

                    if (!roleResult.Succeeded)
                        throw new Exception("System have problems with role defination for admin.");

                }

            }



        }

    }
}
