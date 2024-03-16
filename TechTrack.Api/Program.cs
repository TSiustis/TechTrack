using MediatR.Pipeline;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTrack.Api;
using TechTrack.Application;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Persistence.DatabaseContext;
using TechTrack.Persistence.Repositories;
using TechTrack.Application.Equipments.Queries.GetEquipment;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using TechTrack.Application.Equipments.Queries.GetEquipments;

public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ReadDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
        builder.Services.AddDbContext<WriteDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

        builder.Services.AddScoped<IEquipmentReadRepository, EquipmentReadRepository>();
        builder.Services.AddScoped<IEquipmentWriteRepository, EquipmentWriteRepository>();

        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
        builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(GetEquipmentsQuery).Assembly));
        builder.Services.AddApiVersioning();

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

        if(app.Environment.IsDevelopment())
        {
            await DataSeeder.SeedDataAsync(app.Services);
        }

        app.Run();
    }
}