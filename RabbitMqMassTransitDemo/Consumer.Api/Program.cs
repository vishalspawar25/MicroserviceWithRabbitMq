using Consumer.Api;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMassTransit(config => {

    config.AddConsumer<SubmitOrderConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["RabbitMqUrl"]);

        cfg.ReceiveEndpoint("order-queue", c => {
            c.ConfigureConsumer<SubmitOrderConsumer>(ctx);
        });
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
