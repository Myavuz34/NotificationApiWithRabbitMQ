using MassTransit;
using Microsoft.EntityFrameworkCore;
using Yvz.Notification.CustomerApi.Context;
using Yvz.Notification.CustomerApi.Services;
using Yvz.Notification.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // DbContext

// MassTransit DI
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) => cfg.Host("localhost"));

    x.AddRequestClient<SubmitCustomer>(TimeSpan.FromSeconds(10));
});

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