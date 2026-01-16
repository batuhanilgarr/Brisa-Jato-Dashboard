namespace BrisaVehicleDashboard.Models;

public class VehicleModel
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? Description { get; set; }
    public string? UbyId { get; set; }
    public VehicleBrand? Brand { get; set; }
    public VehicleGroupList? Group { get; set; }
    
    // Raw JSON for displaying all data
    public string? RawJson { get; set; }
}

public class VehicleGroupList
{
    public List<VehicleGroup>? BrisaVehicleGroup { get; set; }
}

public class VehicleModelResponse
{
    public string? Uri { get; set; }
    public List<VehicleModel>? Brisavehiclemodel { get; set; }
}
