namespace DeviceMonitor.Domain;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Room {get; set;} = string.Empty;
    public bool IsOnline { get; set; }
}