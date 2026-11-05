using DeviceMonitor.Application.Devices;
using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Api.Endpoints;

public static class DeviceEndpoints
{
    public static void MapDeviceEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/devices");

        group.MapGet("/", (bool? online, IDeviceRepository repository) =>
        {
            return repository.GetAll(online);
        });

        group.MapGet("/{id:int}", (int id, IDeviceRepository repository) =>
        {
            var device = repository.GetById(id);
            return device is null ? Results.NotFound() : Results.Ok(device);
        });

        group.MapPost("/", (Device device, IDeviceRepository repository) =>
        {
            var created = repository.Add(device);
            return Results.Created($"/devices/{created.Id}", created);
        });
    }
}