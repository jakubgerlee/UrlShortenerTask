
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.DbContext;
using UrlShortener.Data.Repositories;
using UrlShortener.Domain.Abstractions;
using UrlShortener.Domain.Services;

namespace UrlShortener.WebApplication;

public class WebConfigurations
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddDbContext<UrlShortenerContext>(options =>
        {
            options.UseInMemoryDatabase("UrlShortener");

            //if (environtment.IsDevelopment())
            //{
            //    options.UseInMemoryDatabase("UrlShortener");
            //}
            //else
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //}
        });

        services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        services.AddScoped<IUrlShorteningService, UrlShorteningService>();
    }

    public void ConfigureApplication(Microsoft.AspNetCore.Builder.WebApplication app)
    {

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        
        //app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapGet("/health", async context => await context.Response.WriteAsync("Ok"));



    }
}