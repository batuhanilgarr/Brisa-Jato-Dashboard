namespace BrisaVehicleDashboard.Models;

public class VehicleProductYear
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? Description { get; set; }
    public string? UbyId { get; set; }
    public string? ProductYear { get; set; }
    public string? AspectRatio { get; set; }
    public string? RimDiameter { get; set; }
    public string? SectionWidth { get; set; }
    public string? Size { get; set; }
    public string? SpeedIndex { get; set; }
    public string? FrontRear { get; set; }
    public VehicleBrand? Brand { get; set; }
    public VehicleModel? Model { get; set; }
    public VehicleVersion? Version { get; set; }
    public VehicleBodyTypeWrapper? Body { get; set; }
    
    // Raw JSON for displaying all data
    public string? RawJson { get; set; }
}

public class VehicleBodyTypeWrapper
{
    public VehicleBodyType? BrisaVehicleBodyType { get; set; }
}

public class VehicleBodyType
{
    public string? Uri { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Sealed { get; set; }
    public string? UbyId { get; set; }
}

public class VehicleProductYearResponse
{
    public string? Uri { get; set; }
    public List<VehicleProductYear>? Brisavehicleproductyear { get; set; }
}
