# Brisa Jato Dashboard

A modern .NET Blazor Server dashboard application for viewing and searching vehicle data from Brisa Jato backup files.

## Features

- 📊 **Multi-tab Dashboard**: View data across 5 categories:
  - `brisavehiclebrand` - Vehicle brands
  - `brisavehiclegroup` - Vehicle groups
  - `brisavehiclemodel` - Vehicle models
  - `brisavehicleproductyear` - Product years (166K+ records)
  - `brisavehicleversion` - Versions (36K+ records)

- 🔍 **Advanced Search**: Real-time search across all fields
- 📄 **Pagination**: Efficient pagination for large datasets
- 🎨 **Modern UI**: Clean, responsive design with dark theme
- 📱 **Detail Modal**: View complete item details in a popup modal
- 🔗 **JSON Field Names**: Table headers use exact JSON field names
- 📋 **Comprehensive Data Display**: Shows all fields including nested objects

## Technology Stack

- **.NET 10.0**
- **Blazor Server** (Interactive Server mode)
- **Bootstrap 5**
- **Custom CSS** with modern design

## Project Structure

```
BrisaVehicleDashboard/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Pages/
│       └── Dashboard.razor
├── Models/
│   ├── VehicleBrand.cs
│   ├── VehicleGroup.cs
│   ├── VehicleModel.cs
│   ├── VehicleProductYear.cs
│   └── VehicleVersion.cs
├── Services/
│   └── VehicleDataService.cs
└── wwwroot/
    └── dashboard.css
```

## Data Source

The application reads JSON files from the following directories:
- `brisavehiclebrands/`
- `brisavehiclegroups/`
- `brisavehiclemodels/`
- `brisavehicleproductyears/`
- `brisavehicleversions/`

Each directory contains paginated JSON files (e.g., `tr_Page_000.json`, `tr_Page_001.json`).

## Getting Started

### Prerequisites

- .NET 10.0 SDK
- JSON data files in `hybris_jato_backup_20260116/` directory (one level up from project root)

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/batuhanilgarr/Brisa-Jato-Dashboard.git
cd Brisa-Jato-Dashboard
```

2. Ensure JSON data files are in the correct location:
```
brisa_jato_dashboard/
├── BrisaVehicleDashboard/
└── hybris_jato_backup_20260116/
    ├── brisavehiclebrands/
    ├── brisavehiclegroups/
    ├── brisavehiclemodels/
    ├── brisavehicleproductyears/
    └── brisavehicleversions/
```

3. Run the application:
```bash
cd BrisaVehicleDashboard
dotnet run
```

4. Open your browser and navigate to `https://localhost:5001` (or the port shown in the console)

## Usage

1. **Viewing Data**: Click on any tab to view data for that category
2. **Searching**: Use the search box to filter results in real-time
3. **Viewing Details**: Click the "Detay" (Detail) button to see all fields in a modal
4. **Group JSON**: For models, click "JSON Göster" to view group data in parsed format
5. **Pagination**: Use pagination controls for Product Years and Versions tabs

## Table Display

- Each table shows a maximum of 5 columns for optimal viewing
- Additional fields are available in the detail modal
- All field names match the original JSON structure

## License

This project is for internal use.

## Author

Batuhan Ilgar
