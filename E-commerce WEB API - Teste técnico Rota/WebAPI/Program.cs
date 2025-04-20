using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //uTilização de um banco de dados em memoria para simular o gerenciamento de dados
            builder.Services.AddDbContext<DbContextInMemory>(options =>
    options.UseInMemoryDatabase("DevFreelaInMemory"));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
