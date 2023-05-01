using HouseofGunpowder.Data;
using HouseofGunpowder.Repositories;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseofGunpowder {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<GunpowderDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IEmail, EmailRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (app.Environment.IsDevelopment()) {

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}