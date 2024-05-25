
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ProductManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.


            services.AddCors();
            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "ProjectManagementAPI",
                        Version = "v1"
                    });
                }
                );
            //var l3StoreConnectionString = configuration.GetConnectionString("L3StoreDB") ?? throw new InvalidOperationException("Connection string 'L3StoreDB' not found.");
            //services.AddDbContext<MyDbContext>(options =>
            //	options.UseSqlServer(l3StoreConnectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
