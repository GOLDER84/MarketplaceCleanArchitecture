using Microsoft.EntityFrameworkCore;
using Marketplace.Application;
using Marketplace.Application.Interfaces;
using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Repositories;
using Service;
using Service.Interfaces.Repsitoreis;

namespace Mraketplace.Presention
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // builder.Services.AddDbContext<DatabaseManager>(options =>
            //     options.UseSqlServer(connectionString, sqlOptions =>
            //     {
            //         sqlOptions.EnableRetryOnFailure(
            //             maxRetryCount: 5,
            //             maxRetryDelay: TimeSpan.FromSeconds(30),
            //             errorNumbersToAdd: null);
            //     }));
            builder.Services.AddDbContext<DatabaseManager>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
                ));

            builder.Services.AddSingleton<IUserSessionService, UserSessionService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IItemService, ItemService>();

            
            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            Console.WriteLine("Starting Marketplace API...");
            Console.WriteLine($"Using SQL Server: {connectionString?.Split(';')[0]}");

            app.Run();
        }
    }
}
