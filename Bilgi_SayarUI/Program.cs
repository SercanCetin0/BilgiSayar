using Bilgi_SayarUI.Areas.Admin.DependencyResolvers.Ninject;
using Bilgi_SayarUI.DependencyResolvers.Ninject;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Modules;
using Ninject.Web.AspNetCore;

using System.ComponentModel;
using System.Runtime.Loader;
using System.Web;
using Bilgi_SayarUI.Infrastructure;
using Bilgi_SayarUI.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddNinject(new StandardKernel(new AdminModule()));

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureValidationRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureIdentity();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureSession();
builder.Services.AddSession();



var app = builder.Build();

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.ConfugireDefaultAdmin();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints
    (endpoints =>
    {
        endpoints.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Category}/{action=Index}/{id?}");
       
        endpoints.MapAreaControllerRoute(
            name: "Writers",
            areaName: "Writers",
            pattern: "Writers/{controller=Author}/{action=Index}/{id?}"
          );

        endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");


    });

app.Run();
