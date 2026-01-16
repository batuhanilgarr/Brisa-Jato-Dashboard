using System.Text.Json;
using System.Text.Json.Serialization;
using BrisaVehicleDashboard.Models;

namespace BrisaVehicleDashboard.Services;

public class VehicleDataService
{
    private readonly string _basePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public VehicleDataService(IWebHostEnvironment env)
    {
        // Proje BrisaVehicleDashboard içinde, JSON dosyaları bir üst dizinde
        var relativePath = Path.Combine(env.ContentRootPath, "..", "hybris_jato_backup_20260116");
        _basePath = Path.GetFullPath(relativePath);
        
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        // Custom JSON property name mappings
        var customOptions = new JsonSerializerOptions(_jsonOptions);
        customOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public async Task<List<VehicleBrand>> GetAllBrandsAsync()
    {
        var brands = new List<VehicleBrand>();
        var directory = Path.Combine(_basePath, "brisavehiclebrands");
        
        if (!Directory.Exists(directory))
            return brands;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => f);
        
        foreach (var file in files)
        {
            var json = await File.ReadAllTextAsync(file);
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            
            if (root.TryGetProperty("brisavehiclebrand", out var brandArray))
            {
                foreach (var item in brandArray.EnumerateArray())
                {
                    brands.Add(new VehicleBrand
                    {
                        Uri = item.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
                        ModifiedTime = item.TryGetProperty("modifiedtime", out var modTime) 
                            ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
                        Sealed = item.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
                        Description = item.TryGetProperty("description", out var desc) ? desc.GetString() : null,
                        UbyId = item.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null
                    });
                }
            }
        }
        
        return brands;
    }

    public async Task<List<VehicleGroup>> GetAllGroupsAsync()
    {
        var groups = new List<VehicleGroup>();
        var directory = Path.Combine(_basePath, "brisavehiclegroups");
        
        if (!Directory.Exists(directory))
            return groups;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => f);
        
        foreach (var file in files)
        {
            var json = await File.ReadAllTextAsync(file);
            
            // Use dynamic deserialization to handle @ prefix properties
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            
            if (root.TryGetProperty("brisavehiclegroup", out var groupArray))
            {
                foreach (var item in groupArray.EnumerateArray())
                {
                    groups.Add(new VehicleGroup
                    {
                        Uri = item.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
                        ModifiedTime = item.TryGetProperty("modifiedtime", out var modTime) 
                            ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
                        Sealed = item.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
                        UbyId = item.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null
                    });
                }
            }
        }
        
        return groups;
    }

    public async Task<List<VehicleModel>> GetAllModelsAsync()
    {
        var models = new List<VehicleModel>();
        var directory = Path.Combine(_basePath, "brisavehiclemodels");
        
        if (!Directory.Exists(directory))
            return models;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => f);
        
        foreach (var file in files)
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                
                if (root.TryGetProperty("brisavehiclemodel", out var modelArray) && modelArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in modelArray.EnumerateArray())
                {
                    var modelJson = item.GetRawText();
                    var model = new VehicleModel
                    {
                        Uri = item.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
                        ModifiedTime = item.TryGetProperty("modifiedtime", out var modTime) 
                            ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
                        Sealed = item.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
                        Description = item.TryGetProperty("description", out var desc) ? desc.GetString() : null,
                        UbyId = item.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null,
                        RawJson = modelJson
                    };

                    // Parse brand
                    if (item.TryGetProperty("brand", out var brandEl) && brandEl.ValueKind == JsonValueKind.Object)
                    {
                        model.Brand = ParseBrand(brandEl);
                    }

                    // Parse groups
                    if (item.TryGetProperty("group", out var groupEl) && groupEl.ValueKind == JsonValueKind.Object)
                    {
                        if (groupEl.TryGetProperty("brisaVehicleGroup", out var groupArray) && groupArray.ValueKind == JsonValueKind.Array)
                        {
                            var groups = new List<VehicleGroup>();
                            foreach (var g in groupArray.EnumerateArray())
                            {
                                groups.Add(ParseGroup(g));
                            }
                            model.Group = new VehicleGroupList { BrisaVehicleGroup = groups };
                        }
                    }

                    models.Add(model);
                }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing model file {file}: {ex.Message}");
                // Continue with next file
            }
        }
        
        return models;
    }

    private VehicleBrand ParseBrand(JsonElement brandEl)
    {
        return new VehicleBrand
        {
            Uri = brandEl.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
            ModifiedTime = brandEl.TryGetProperty("modifiedtime", out var modTime) 
                ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
            Sealed = brandEl.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
            Description = brandEl.TryGetProperty("description", out var desc) ? desc.GetString() : null,
            UbyId = brandEl.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null
        };
    }

    private VehicleGroup ParseGroup(JsonElement groupEl)
    {
        return new VehicleGroup
        {
            Uri = groupEl.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
            ModifiedTime = groupEl.TryGetProperty("modifiedtime", out var modTime) 
                ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
            Sealed = groupEl.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
            UbyId = groupEl.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null
        };
    }

    public async Task<List<VehicleProductYear>> GetAllProductYearsAsync()
    {
        var years = new List<VehicleProductYear>();
        var directory = Path.Combine(_basePath, "brisavehicleproductyears");
        
        if (!Directory.Exists(directory))
            return years;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => f);
        
        foreach (var file in files)
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                
                if (root.TryGetProperty("brisavehicleproductyear", out var yearArray) && yearArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in yearArray.EnumerateArray())
                {
                    var yearJson = item.GetRawText();
                    var year = new VehicleProductYear
                    {
                        Uri = item.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
                        ModifiedTime = item.TryGetProperty("modifiedtime", out var modTime) 
                            ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
                        Sealed = item.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
                        Description = item.TryGetProperty("description", out var desc) ? desc.GetString() : null,
                        UbyId = item.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null,
                        ProductYear = item.TryGetProperty("productYear", out var py) ? py.GetString() : null,
                        AspectRatio = item.TryGetProperty("aspectRatio", out var ar) ? ar.GetString() : null,
                        RimDiameter = item.TryGetProperty("rimDiameter", out var rd) ? rd.GetString() : null,
                        SectionWidth = item.TryGetProperty("sectionWidth", out var sw) ? sw.GetString() : null,
                        Size = item.TryGetProperty("size", out var sz) ? sz.GetString() : null,
                        SpeedIndex = item.TryGetProperty("speedIndex", out var si) ? si.GetString() : null,
                        FrontRear = item.TryGetProperty("frontRear", out var fr) ? fr.GetString() : null,
                        RawJson = yearJson
                    };

                    // Parse nested objects
                    if (item.TryGetProperty("brand", out var brandEl) && brandEl.ValueKind == JsonValueKind.Object)
                    {
                        year.Brand = ParseBrand(brandEl);
                    }

                    if (item.TryGetProperty("model", out var modelEl) && modelEl.ValueKind == JsonValueKind.Object)
                    {
                        year.Model = ParseModel(modelEl);
                    }

                    if (item.TryGetProperty("version", out var versionEl) && versionEl.ValueKind == JsonValueKind.Object)
                    {
                        year.Version = ParseVersion(versionEl);
                    }

                    // Parse body
                    if (item.TryGetProperty("body", out var bodyEl) && bodyEl.ValueKind == JsonValueKind.Object)
                    {
                        if (bodyEl.TryGetProperty("brisaVehicleBodyType", out var bodyTypeEl) && bodyTypeEl.ValueKind == JsonValueKind.Object)
                        {
                            year.Body = new VehicleBodyTypeWrapper
                            {
                                BrisaVehicleBodyType = new VehicleBodyType
                                {
                                    Uri = bodyTypeEl.TryGetProperty("@uri", out var btUri) ? btUri.GetString() : null,
                                    ModifiedTime = bodyTypeEl.TryGetProperty("modifiedtime", out var btModTime) 
                                        ? DateTime.TryParse(btModTime.GetString(), out var btDt) ? btDt : null : null,
                                    Sealed = bodyTypeEl.TryGetProperty("sealed", out var btSealed) ? btSealed.GetString() : null,
                                    UbyId = bodyTypeEl.TryGetProperty("ubyId", out var btUbyId) ? btUbyId.GetString() : null
                                }
                            };
                        }
                    }

                    years.Add(year);
                }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing product year file {file}: {ex.Message}");
                // Continue with next file
            }
        }
        
        return years;
    }

    private VehicleModel ParseModel(JsonElement modelEl)
    {
        return new VehicleModel
        {
            Uri = modelEl.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
            ModifiedTime = modelEl.TryGetProperty("modifiedtime", out var modTime) 
                ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
            Sealed = modelEl.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
            Description = modelEl.TryGetProperty("description", out var desc) ? desc.GetString() : null,
            UbyId = modelEl.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null
        };
    }

    private VehicleVersion ParseVersion(JsonElement versionEl)
    {
        return new VehicleVersion
        {
            Uri = versionEl.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
            ModifiedTime = versionEl.TryGetProperty("modifiedtime", out var modTime) 
                ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
            Sealed = versionEl.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
            Description = versionEl.TryGetProperty("description", out var desc) ? desc.GetString() : null,
            UbyId = versionEl.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null,
            VersionCode = versionEl.TryGetProperty("versionCode", out var vc) ? vc.GetString() : null
        };
    }

    public async Task<List<VehicleVersion>> GetAllVersionsAsync()
    {
        var versions = new List<VehicleVersion>();
        var directory = Path.Combine(_basePath, "brisavehicleversions");
        
        if (!Directory.Exists(directory))
            return versions;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => f);
        
        foreach (var file in files)
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                
                if (root.TryGetProperty("brisavehicleversion", out var versionArray) && versionArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in versionArray.EnumerateArray())
                {
                    var versionJson = item.GetRawText();
                    var version = new VehicleVersion
                    {
                        Uri = item.TryGetProperty("@uri", out var uri) ? uri.GetString() : null,
                        ModifiedTime = item.TryGetProperty("modifiedtime", out var modTime) 
                            ? DateTime.TryParse(modTime.GetString(), out var dt) ? dt : null : null,
                        Sealed = item.TryGetProperty("sealed", out var sealedProp) ? sealedProp.GetString() : null,
                        Description = item.TryGetProperty("description", out var desc) ? desc.GetString() : null,
                        UbyId = item.TryGetProperty("ubyId", out var ubyId) ? ubyId.GetString() : null,
                        VersionCode = item.TryGetProperty("versionCode", out var vc) ? vc.GetString() : null,
                        RawJson = versionJson
                    };

                    // Parse model
                    if (item.TryGetProperty("model", out var modelEl) && modelEl.ValueKind == JsonValueKind.Object)
                    {
                        version.Model = ParseModel(modelEl);
                    }

                    versions.Add(version);
                }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing version file {file}: {ex.Message}");
                // Continue with next file
            }
        }
        
        return versions;
    }

    // Pagination methods
    public async Task<PagedResult<VehicleProductYear>> GetProductYearsPagedAsync(int pageNumber, int pageSize, string? searchTerm = null)
    {
        var allYears = await GetAllProductYearsAsync();
        var filtered = ApplySearchToProductYears(allYears, searchTerm);
        
        var totalCount = filtered.Count;
        var items = filtered
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedResult<VehicleProductYear>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<PagedResult<VehicleVersion>> GetVersionsPagedAsync(int pageNumber, int pageSize, string? searchTerm = null)
    {
        var allVersions = await GetAllVersionsAsync();
        var filtered = ApplySearchToVersions(allVersions, searchTerm);
        
        var totalCount = filtered.Count;
        var items = filtered
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedResult<VehicleVersion>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    // Helper methods for search
    private List<VehicleProductYear> ApplySearchToProductYears(List<VehicleProductYear> items, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return items;
        
        var term = searchTerm.ToLowerInvariant();
        return items.Where(y =>
            (y.Description?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.UbyId?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.Uri?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.ProductYear?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.Size?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.Brand?.Description?.ToLowerInvariant().Contains(term) ?? false) ||
            (y.Model?.Description?.ToLowerInvariant().Contains(term) ?? false)
        ).ToList();
    }

    private List<VehicleVersion> ApplySearchToVersions(List<VehicleVersion> items, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return items;
        
        var term = searchTerm.ToLowerInvariant();
        return items.Where(v =>
            (v.Description?.ToLowerInvariant().Contains(term) ?? false) ||
            (v.UbyId?.ToLowerInvariant().Contains(term) ?? false) ||
            (v.Uri?.ToLowerInvariant().Contains(term) ?? false) ||
            (v.VersionCode?.ToLowerInvariant().Contains(term) ?? false) ||
            (v.Model?.Description?.ToLowerInvariant().Contains(term) ?? false)
        ).ToList();
    }
}
