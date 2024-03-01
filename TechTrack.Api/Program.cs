using Microsoft.EntityFrameworkCore;
using TechTrack.Application;
using TechTrack.Data;
using TechTrack.Domain.Interfaces;
using TechTrack.Infrastructure.Data;
using TechTrack.Infrastructure.Repositories;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TechTrackDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("TechTrackDatabase")));
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
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
