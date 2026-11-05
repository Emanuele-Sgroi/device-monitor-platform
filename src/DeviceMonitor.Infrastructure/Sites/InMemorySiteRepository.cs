using DeviceMonitor.Application.Sites;
using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Infrastructure.Sites;

public class InMemorySiteRepository : ISiteRepository
{
    private readonly List<Site> _sites = new()
    {
        new() {Id = 1, Name = "Warehouse", City = "Rome", IsActive = true},
        new() {Id = 2, Name = "Restaurant", City = "Catania", IsActive = true},
        new() {Id = 3, Name = "Head Office", City = "Milan", IsActive = false},
    };

    public IReadOnlyList<Site> GetAll(string? city)
    {
        if (city is null)
        {
            return _sites;
        }
        
        return _sites.Where(c => c.City == city).ToList();
    }

    public Site? GetById(int id)
    {
        return _sites.FirstOrDefault(s => s.Id == id);
    }

    public Site Add(Site site)
    {
        site.Id = _sites.Max(s => s.Id) + 1;
        _sites.Add(site);
        return site;
    }
}