namespace BrisaVehicleDashboard.Models;

public class VehicleVersion
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? Description { get; set; }
    public string? UbyId { get; set; }
    public string? VersionCode { get; set; }
    public VehicleModel? Model { get; set; }
    
    // Raw JSON for displaying all data
    public string? RawJson { get; set; }
}

public class VehicleVersionResponse
{
    public string? Uri { get; set; }
    public List<VehicleVersion>? Brisavehicleversion { get; set; }
}
