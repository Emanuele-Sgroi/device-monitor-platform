using DeviceMonitor.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Temporary in-memory data (replaced by PostgreSQL later)
var devices = new List<Device>
{
    new () {Id = 1, Name = "Living room sensor", Room = "Living room", IsOnline = true},
    new () {Id = 2, Name = "Office sensor", Room = "Office", IsOnline = false},
};

// Device endpoints
app.MapGet("/devices/{id:int}", (int id) =>
{
    var device = devices.FirstOrDefault(x => x.Id == id);
    return device is null ? Results.NotFound() : Results.Ok(device);
});

app.MapGet("/devices", (bool? online) =>
{

    if (online is null)
    {
        return devices;
    }

    return devices.Where(x => x.IsOnline == online).ToList();
});

app.MapPost("/devices", (Device device) =>
{
    device.Id = devices.Max(x => x.Id) + 1;
    devices.Add(device);
    return Results.Created($"/devices/{device.Id}", device);
});

app.Run();
