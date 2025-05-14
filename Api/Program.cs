using Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //add infrastructure services
            builder.Services.AddInfrastructureServices(builder.Configuration);

        
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();         // <-- T?o file JSON mô t? API
                app.UseSwaggerUI();      // <-- Giao di?n UI hi?n th? Swagger
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
