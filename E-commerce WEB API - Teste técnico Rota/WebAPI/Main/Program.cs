using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Services;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Infrastructure.AuthenticationService;
using E_commerce_WEB_API___Teste_técnico_Rota.Infrastructure.ExternalService.InterfaceNotification;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.SideServerMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Configuração do Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "E-Commerce API",
                    Version = "v1",
                    Description = "API - teste técnico Rota",
                    Contact = new OpenApiContact
                    {
                        Name = "Paulo Andrade",
                        Email = "parthur207@gmail.com"
                    }
                });
            });

            builder.Services.AddScoped<IAdminProductInterface, AdminProductService>();
            builder.Services.AddScoped<IAdminTransactionInterface, AdminTransactionService>();
            builder.Services.AddScoped<IAdminUserInterface, AdminUserService>();
            builder.Services.AddScoped<IAdminTransactionProductInterface, AdminProductService>();

            builder.Services.AddScoped<IProductInterface, ProductService>();
            builder.Services.AddScoped<ITransactionInterface, TransactionService>();
            builder.Services.AddScoped<IUserInterface, UserService>();

            builder.Services.AddTransient<INotificationInterface, NotificationService>();



            builder.Services.AddDbContext<DbContextInMemory>(options =>
                options.UseInMemoryDatabase("DbContextInMemory"));

            var app = builder.Build();

            // Configura o pipeline de requisições
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API v1");
                    
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}