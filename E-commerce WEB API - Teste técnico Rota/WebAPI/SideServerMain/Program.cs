using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.OpenApi.Models;
using System;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.SideServerMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner antes de Build()
            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen(); // Registra o Swagger


            builder.Services.AddDbContext<DbContextInMemory>(options =>
          options.UseInMemoryDatabase("DbContextInMemory"));

            var app = builder.Build();


            // Configura o middleware do pipeline de requisições
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API v1");

                    c.RoutePrefix = string.Empty; // Acessa diretamente na raiz "/"
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
