
using Application.Interfaces;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.DataBase;
using Infrastructure.Repository;
using WebApi.Validation;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  
            builder.Services.AddSingleton<IDbContext, DataBaseContext>();
            builder.Services.AddScoped<IConsorcioUseCase, ConsorcioUseCases>();

            builder.Services.AddScoped<IConsorcioEntidade, ConsorcioRepositorio>();

            builder.Services.AddTransient<IValidator, ValidarRequisicaoConsorcio>();
            builder.Services.AddControllers().AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<ValidarRequisicaoConsorcio>(); });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  
            if (app.Environment.IsDevelopment())
            {
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