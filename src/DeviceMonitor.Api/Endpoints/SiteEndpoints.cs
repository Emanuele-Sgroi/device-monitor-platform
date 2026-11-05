using DeviceMonitor.Application.Sites;
using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Api.Endpoints;

public static class SiteEndpoints
{
    public static void MapSiteEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/sites");
        
        group.MapGet("/", (string? city, ISiteRepository repository) =>
        {
            return repository.GetAll(city);
        });

        group.MapGet("/{id:int}", (int id, ISiteRepository repository) =>
        {
            var site = repository.GetById(id);
            return site is null ? Results.NotFound() : Results.Ok(site);
        });

        group.MapPost("/", (Site site, ISiteRepository repository) =>
        {
            var created = repository.Add(site);
            return Results.Created($"/sites/{created.Id}", created);
        });
    }
}