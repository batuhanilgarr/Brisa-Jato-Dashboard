namespace BrisaVehicleDashboard.Models;

public class VehicleBrand
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? Description { get; set; }
    public string? UbyId { get; set; }
}

public class VehicleBrandResponse
{
    public string? Uri { get; set; }
    public List<VehicleBrand>? Brisavehiclebrand { get; set; }
}
