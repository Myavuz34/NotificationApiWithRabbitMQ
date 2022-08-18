using MassTransit;
using Yvz.Notifcation.Api;
using Yvz.Notifcation.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<CustomerConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost/"));
        cfg.ReceiveEndpoint("LCustomer", c => { c.ConfigureConsumer<CustomerConsumer>(context); });
    });
});

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