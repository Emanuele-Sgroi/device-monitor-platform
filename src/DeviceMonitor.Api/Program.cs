using DeviceMonitor.Api.Endpoints;
using DeviceMonitor.Application.Devices;
using DeviceMonitor.Application.Sites;
using DeviceMonitor.Infrastructure.Devices;
using DeviceMonitor.Infrastructure.Sites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IDeviceRepository, InMemoryDeviceRepository>();
builder.Services.AddSingleton<ISiteRepository, InMemorySiteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapDeviceEndpoints();
app.MapSiteEndpoints();

app.Run();
