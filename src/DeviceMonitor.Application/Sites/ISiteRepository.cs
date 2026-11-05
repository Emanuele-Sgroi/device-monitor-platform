using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Application.Sites;

public interface ISiteRepository
{
    IReadOnlyList<Site> GetAll(string? city);
    Site? GetById(int id);
    Site Add(Site site);
}