using Carter;
using FastFood.Catalogo.Endpoints.IoC;
using FastFood.Pedidos.Endpoints.IoC;
using FastFood.WebApi.Configurations;
using FastFood.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPedidoModule(builder.Configuration, builder);
builder.Services.AddCatalogoModule(builder.Configuration, builder);

builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthCheck();
app.UseHttpsRedirection();
app.MapCarter();
app.UseGlobalExceptionHandlerMiddleware();

app.UsePedidoModule();
app.UseCatalogoModule();

app.Run();