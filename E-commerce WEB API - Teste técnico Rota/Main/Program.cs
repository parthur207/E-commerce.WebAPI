using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Application.Services.AdminServices;
using Ecommerce.Application.Services.CommomServices;
using Ecommerce.Infrastructure.Auth;
using Ecommerce.Infrastructure.Auth.JwtInterface;
using Ecommerce.Infrastructure.ExternalService;
using Ecommerce.Infrastructure.ExternalService.InterfaceNotification;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //Configuração do Swagger
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

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Informe o token JWT: Bearer {seu token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            //banco de dados InMemory
            builder.Services.AddDbContext<DbContextInMemory>(options =>
                options.UseInMemoryDatabase("DbContextInMemory"));

            //Banco de dados SQL
            /*var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Conexão: {cnn}");

            builder.Services.AddDbContext<DbContextInMemory>(options => options.UseSqlServer(cnn));*/


            builder.Services.AddScoped<IAdminProductInterface, AdminProductService>();
            builder.Services.AddScoped<IAdminTransactionInterface, AdminTransactionService>();
            builder.Services.AddScoped<IAdminUserInterface, AdminUserService>();
            builder.Services.AddScoped<IProductInterface, ProductService>();
            builder.Services.AddScoped<ITransactionInterface, TransactionService>();
            builder.Services.AddScoped<IUserInterface, UserService>();


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            builder.Services.AddScoped<IJwtInterface, JwtService>();


            builder.Services.AddTransient<INotificationInterface, NotificationService>();

            //Autenticação JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            //Autorização
            builder.Services.AddAuthorization();

            var app = builder.Build();

            //pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API v1");
                });
            }
         

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
