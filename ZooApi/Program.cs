using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using ZooApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ZooContext>(options =>
        options.UseInMemoryDatabase("ZooDb"));

builder.Services.AddScoped<IZooRepository, InMemoryZooRepository>();
builder.Services.AddScoped<ZooService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ZooContext>();
    context.Database.EnsureCreated();

    if (!context.Animals.Any())
    {
        context.Animals.AddRange(
            new Carnivore { Id = 1, Name = "Lion", Type = "Carnivore" },
            new Carnivore { Id = 2, Name = "Tiger", Type = "Carnivore" },
            new Herbivore { Id = 3, Name = "Elephant", Type = "Herbivore" },
            new Giraffe { Id = 4, Name = "Giraffe", Type = "Giraffe" }
        );

        context.FoodSupplies.Add(new FoodSupply { Id = 1, Amount = 100 });
        context.SaveChanges();
    }
}

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
