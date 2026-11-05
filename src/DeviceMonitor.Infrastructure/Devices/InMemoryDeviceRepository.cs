using DeviceMonitor.Application.Devices;
using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Infrastructure.Devices;

public class InMemoryDeviceRepository : IDeviceRepository
{
    private readonly List<Device> _devices = new()
    {
        new() { Id = 1, Name = "Living room sensor", Room = "Living room", IsOnline = true },
        new() { Id = 2, Name = "Office sensor", Room = "Office", IsOnline = false },
    };

    public IReadOnlyList<Device> GetAll(bool? online)
    {
        if (online is null)
        {
            return _devices;
        }
        
        
        return _devices.Where(d => d.IsOnline == online).ToList();
    }

    public Device? GetById(int id)
    {
        return _devices.FirstOrDefault(d => d.Id == id);
    }

    public Device Add(Device device)
    {
        device.Id = _devices.Max(d => d.Id) + 1;
        _devices.Add(device);
        return device;
    }
}