using DeviceMonitor.Domain.Entities;

namespace DeviceMonitor.Application.Devices;

public interface IDeviceRepository
{
    IReadOnlyList<Device> GetAll(bool? online);
    Device? GetById(int id);
    Device Add(Device device);
}