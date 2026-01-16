namespace BrisaVehicleDashboard.Models;

public class VehicleGroup
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? UbyId { get; set; }
}

public class VehicleGroupResponse
{
    public string? Uri { get; set; }
    public List<VehicleGroup>? Brisavehiclegroup { get; set; }
}
