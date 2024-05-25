using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace AjaxClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //var l3StoreConnectionString = configuration.GetConnectionString("L3StoreDB")
            //    ?? throw new InvalidOperationException("Connection string 'L3StoreDB' not found.");
            //services.AddDbContext<MyDbContext>(options =>
            //    options.UseSqlServer(l3StoreConnectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
