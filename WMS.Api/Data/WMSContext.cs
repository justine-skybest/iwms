using Microsoft.EntityFrameworkCore;
using WMS.Api.Entities;

namespace WMS.Api.Data;

public class WMSContext(DbContextOptions<WMSContext> options) 
    : DbContext(options)
{
    public DbSet<Warehouse>  Warehouses => Set<Warehouse>();

    public DbSet<Rack> Racks => Set<Rack>();
    
    public DbSet<RackFloorMapObject> RackFloorMapObjects => Set<RackFloorMapObject>();

    public DbSet<Bin> Bins => Set<Bin>();

    public DbSet<Bay> Bays => Set<Bay>();

    public DbSet<Level> Levels => Set<Level>();

    public DbSet<BinNames> BinNames => Set<BinNames>();

    public DbSet<Product> Products => Set<Product>();
    
    public DbSet<Receiving> Receivings => Set<Receiving>();
    public DbSet<Incoming> Incomings => Set<Incoming>();

    public DbSet<ReceivedProduct> ReceivedProducts => Set<ReceivedProduct>();

    public DbSet<CheckIn> CheckIns => Set<CheckIn>();
    
    public DbSet<Pallet> Pallets => Set<Pallet>();

    public DbSet<ManualPicking> ManualPickings => Set<ManualPicking>();

    public DbSet<PickedProduct> PickedProducts => Set<PickedProduct>();

    public DbSet<TransferLog> TransferLogs => Set<TransferLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // IncomingProduct Precision
        modelBuilder.Entity<IncomingProduct>(builder =>
        {
            builder.Property(p => p.UnitPrice).HasPrecision(18, 2);
            builder.Property(p => p.TotalAmount).HasPrecision(18, 2);
            builder.Property(p => p.TotalWeight).HasPrecision(18, 2);
            builder.Property(p => p.CBM).HasPrecision(18, 4);
        });

        modelBuilder.Entity<ReceivedProduct>(builder =>
        {
            builder.Property(p => p.TotalWeight).HasPrecision(18, 2);
            builder.Property(p => p.CBM).HasPrecision(18, 4);
        });

        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(p => p.Weight).HasPrecision(18, 2);
            builder.Property(p => p.Measurement).HasPrecision(18, 4);
        });

        modelBuilder.Entity<Bay>().HasData(
            new{Id = 1, BayNumber = 1},
            new{Id = 2, BayNumber = 2},
            new{Id = 3, BayNumber = 3},
            new{Id = 4, BayNumber = 4},
            new{Id = 5, BayNumber = 5},
            new{Id = 6, BayNumber = 6},
            new{Id = 7, BayNumber = 7},
            new{Id = 8, BayNumber = 8},
            new{Id = 9, BayNumber = 9},
            new{Id = 10, BayNumber = 10}
      );

      modelBuilder.Entity<Level>().HasData(
            new{Id = 1, LevelNumber = 1},
            new{Id = 2, LevelNumber = 2},
            new{Id = 3, LevelNumber = 3},
            new{Id = 4, LevelNumber = 4},
            new{Id = 5, LevelNumber = 5},
            new{Id = 6, LevelNumber = 6},
            new{Id = 7, LevelNumber = 7},
            new{Id = 8, LevelNumber = 8},
            new{Id = 9, LevelNumber = 9},
            new{Id = 10, LevelNumber = 10}
      );

      modelBuilder.Entity<BinNames>().HasData(
            new{Id = 1, BinName = "Bin 1"},
            new{Id = 2, BinName = "Bin 2"},
            new{Id = 3, BinName = "Bin 3"},
            new{Id = 4, BinName = "Bin 4"}
      );

      modelBuilder.Entity<Warehouse>().HasData(
            new{Id = 1, Name = "SKYBEST WAREHOUSE 6", Address = "NIOG ST BACOOR CAVITE", DateAdded = Convert.ToDateTime("2024-12-10 08:04:17.763916")},                  
            new{Id = 2, Name = "Legalas Warehouse", Address = "Babanse St, Navotas City", DateAdded = Convert.ToDateTime("2025-05-29 08:04:17.763916")}
      );

      modelBuilder.Entity<Rack>().HasData(
            new{Id = 1, Name = "Metal Shelving 1", WarehouseId = 1, BayId = 3, LevelId = 3, IsFloorDocking = false , DateAdded = DateTime.Now},
            new{Id = 2, Name = "Metal Shelving 2", WarehouseId = 1, BayId = 1, LevelId = 5, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 3, Name = "Pallet Racking 1", WarehouseId = 1, BayId = 3, LevelId = 4, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 4, Name = "Pallet Racking 2", WarehouseId = 1, BayId = 6, LevelId = 4, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 5, Name = "Pallet Racking 3", WarehouseId = 1, BayId = 3, LevelId = 4, IsFloorDocking = false, DateAdded = DateTime.Now},            
            new{Id = 6, Name = "Crossdocking 1", WarehouseId = 1, BayId = 2, LevelId = 7, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 7, Name = "Crossdocking 2", WarehouseId = 1, BayId = 2, LevelId = 7, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 8, Name = "Crossdocking 3", WarehouseId = 1, BayId = 2, LevelId = 7, IsFloorDocking = false, DateAdded = DateTime.Now},
            new{Id = 9, Name = "Crossdocking 4", WarehouseId = 1, BayId = 1, LevelId = 7, IsFloorDocking = false, DateAdded = DateTime.Now}

      );

      modelBuilder.Entity<Bin>().HasData(
            new{Id = 1, RackId = 1, BayId = 1, LevelId = 1, BinNamesId = 1, BinHashCode = 976636213, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")},            
            new{Id = 2, RackId = 1, BayId = 1, LevelId = 2, BinNamesId = 1, BinHashCode = -1979248654, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 3, RackId = 1, BayId = 1, LevelId = 3, BinNamesId = 1, BinHashCode = 1673490748, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 4, RackId = 1, BayId = 2, LevelId = 1, BinNamesId = 1, BinHashCode = 1701384564, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 5, RackId = 1, BayId = 2, LevelId = 2, BinNamesId = 1, BinHashCode = 196724902, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 6, RackId = 1, BayId = 2, LevelId = 3, BinNamesId = 1, BinHashCode = -484174977, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 7, RackId = 1, BayId = 3, LevelId = 1, BinNamesId = 1, BinHashCode = -1790539235, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 8, RackId = 1, BayId = 3, LevelId = 2, BinNamesId = 1, BinHashCode = 642809004, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 9, RackId = 1, BayId = 3, LevelId = 3, BinNamesId = 1, BinHashCode = -1992005959, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            
            new{Id = 10, RackId = 2, BayId = 1, LevelId = 1, BinNamesId = 1, BinHashCode = -902286026, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 11, RackId = 2, BayId = 1, LevelId = 2, BinNamesId = 1, BinHashCode = 485716536, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 12, RackId = 2, BayId = 1, LevelId = 3, BinNamesId = 1, BinHashCode = 120754032, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 13, RackId = 2, BayId = 1, LevelId = 4, BinNamesId = 1, BinHashCode = -767892144, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 14, RackId = 2, BayId = 1, LevelId = 5, BinNamesId = 1, BinHashCode = -105527948, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 

            new{Id = 15, RackId = 3, BayId = 1, LevelId = 1, BinNamesId = 1, BinHashCode = -1285803628, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 16, RackId = 3, BayId = 1, LevelId = 1, BinNamesId = 2, BinHashCode = 800775118, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 17, RackId = 3, BayId = 1, LevelId = 2, BinNamesId = 1, BinHashCode = 1019046532, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 18, RackId = 3, BayId = 1, LevelId = 2, BinNamesId = 2, BinHashCode = 719689299, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 19, RackId = 3, BayId = 1, LevelId = 3, BinNamesId = 1, BinHashCode = 276386526, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 20, RackId = 3, BayId = 1, LevelId = 3, BinNamesId = 2, BinHashCode = 1871078101, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 21, RackId = 3, BayId = 1, LevelId = 4, BinNamesId = 1, BinHashCode = -341256051, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 22, RackId = 3, BayId = 1, LevelId = 4, BinNamesId = 2, BinHashCode = 641176255, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 23, RackId = 3, BayId = 2, LevelId = 1, BinNamesId = 1, BinHashCode = -1555901299, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 24, RackId = 3, BayId = 2, LevelId = 1, BinNamesId = 2, BinHashCode = -1585561989, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 25, RackId = 3, BayId = 2, LevelId = 2, BinNamesId = 1, BinHashCode = 1053115519, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 26, RackId = 3, BayId = 2, LevelId = 2, BinNamesId = 2, BinHashCode = -479592046, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 27, RackId = 3, BayId = 2, LevelId = 3, BinNamesId = 1, BinHashCode = -1228370061, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 28, RackId = 3, BayId = 2, LevelId = 3, BinNamesId = 2, BinHashCode = 1245142399, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 29, RackId = 3, BayId = 2, LevelId = 4, BinNamesId = 1, BinHashCode = -652623830, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 30, RackId = 3, BayId = 2, LevelId = 4, BinNamesId = 2, BinHashCode = 1485157462, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 31, RackId = 3, BayId = 3, LevelId = 1, BinNamesId = 1, BinHashCode = -1358792930, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 32, RackId = 3, BayId = 3, LevelId = 1, BinNamesId = 2, BinHashCode = -346485753, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 33, RackId = 3, BayId = 3, LevelId = 2, BinNamesId = 1, BinHashCode = 1185566390, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 34, RackId = 3, BayId = 3, LevelId = 2, BinNamesId = 2, BinHashCode = -1450237118, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 35, RackId = 3, BayId = 3, LevelId = 3, BinNamesId = 1, BinHashCode = 1150083063, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 36, RackId = 3, BayId = 3, LevelId = 3, BinNamesId = 2, BinHashCode = -1122546266, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 37, RackId = 3, BayId = 3, LevelId = 4, BinNamesId = 1, BinHashCode = -1317167336, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 38, RackId = 3, BayId = 3, LevelId = 4, BinNamesId = 2, BinHashCode = 187127893, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 

            new{Id = 39, RackId = 4, BayId = 1, LevelId = 1, BinNamesId = 1, BinHashCode = -1850022207, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 40, RackId = 4, BayId = 1, LevelId = 1, BinNamesId = 2, BinHashCode = 1318415253, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 41, RackId = 4, BayId = 1, LevelId = 2, BinNamesId = 1, BinHashCode = -18621311, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 42, RackId = 4, BayId = 1, LevelId = 2, BinNamesId = 2, BinHashCode = 1420536157, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 43, RackId = 4, BayId = 1, LevelId = 3, BinNamesId = 1, BinHashCode = 1062200443, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 44, RackId = 4, BayId = 1, LevelId = 3, BinNamesId = 2, BinHashCode = -1512804114, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 45, RackId = 4, BayId = 1, LevelId = 4, BinNamesId = 1, BinHashCode = 527966408, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 46, RackId = 4, BayId = 1, LevelId = 4, BinNamesId = 2, BinHashCode = 511745895, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 47, RackId = 4, BayId = 2, LevelId = 1, BinNamesId = 1, BinHashCode = 116982465, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 48, RackId = 4, BayId = 2, LevelId = 1, BinNamesId = 2, BinHashCode = 1654232790, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 49, RackId = 4, BayId = 2, LevelId = 2, BinNamesId = 1, BinHashCode = 334109798, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 50, RackId = 4, BayId = 2, LevelId = 2, BinNamesId = 2, BinHashCode = 1123410421, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 51, RackId = 4, BayId = 2, LevelId = 3, BinNamesId = 1, BinHashCode = -2108006358, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 52, RackId = 4, BayId = 2, LevelId = 3, BinNamesId = 2, BinHashCode = 395006760, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")},             
            new{Id = 53, RackId = 4, BayId = 2, LevelId = 4, BinNamesId = 1, BinHashCode = 2010979598, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 54, RackId = 4, BayId = 2, LevelId = 4, BinNamesId = 2, BinHashCode = -40662049, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 55, RackId = 4, BayId = 3, LevelId = 1, BinNamesId = 1, BinHashCode = -1084611347, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 56, RackId = 4, BayId = 3, LevelId = 1, BinNamesId = 2, BinHashCode = -1787215891, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 57, RackId = 4, BayId = 3, LevelId = 2, BinNamesId = 1, BinHashCode = -1643181944, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 58, RackId = 4, BayId = 3, LevelId = 2, BinNamesId = 2, BinHashCode = 1321412513, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 59, RackId = 4, BayId = 3, LevelId = 3, BinNamesId = 1, BinHashCode = -763942232, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 60, RackId = 4, BayId = 3, LevelId = 3, BinNamesId = 2, BinHashCode = -2056561571, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 61, RackId = 4, BayId = 3, LevelId = 4, BinNamesId = 1, BinHashCode = -2118881999, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 62, RackId = 4, BayId = 3, LevelId = 4, BinNamesId = 2, BinHashCode = -470185763, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 63, RackId = 4, BayId = 4, LevelId = 1, BinNamesId = 1, BinHashCode = -1658049340, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 64, RackId = 4, BayId = 4, LevelId = 1, BinNamesId = 2, BinHashCode = 844845106, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 65, RackId = 4, BayId = 4, LevelId = 2, BinNamesId = 1, BinHashCode = -1669224409, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 66, RackId = 4, BayId = 4, LevelId = 2, BinNamesId = 2, BinHashCode = -358179989, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 67, RackId = 4, BayId = 4, LevelId = 3, BinNamesId = 1, BinHashCode = -1955242011, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 68, RackId = 4, BayId = 4, LevelId = 3, BinNamesId = 2, BinHashCode = 1958354202, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 69, RackId = 4, BayId = 4, LevelId = 4, BinNamesId = 1, BinHashCode = 1825131077, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 70, RackId = 4, BayId = 4, LevelId = 4, BinNamesId = 2, BinHashCode = -169292521, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 71, RackId = 4, BayId = 5, LevelId = 1, BinNamesId = 1, BinHashCode = -1517118774, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 72, RackId = 4, BayId = 5, LevelId = 1, BinNamesId = 2, BinHashCode = 1886512625, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 73, RackId = 4, BayId = 5, LevelId = 2, BinNamesId = 1, BinHashCode = -1449568076, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 74, RackId = 4, BayId = 5, LevelId = 2, BinNamesId = 2, BinHashCode = -343470659, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 75, RackId = 4, BayId = 5, LevelId = 3, BinNamesId = 1, BinHashCode = -1614793922, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 76, RackId = 4, BayId = 5, LevelId = 3, BinNamesId = 2, BinHashCode = -56520126, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 77, RackId = 4, BayId = 5, LevelId = 4, BinNamesId = 1, BinHashCode = 692756103, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 78, RackId = 4, BayId = 5, LevelId = 4, BinNamesId = 2, BinHashCode = 1833364874, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 79, RackId = 4, BayId = 6, LevelId = 1, BinNamesId = 1, BinHashCode = 2005043736, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 80, RackId = 4, BayId = 6, LevelId = 1, BinNamesId = 2, BinHashCode = 2046651153, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 81, RackId = 4, BayId = 6, LevelId = 2, BinNamesId = 1, BinHashCode = -933943777, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 82, RackId = 4, BayId = 6, LevelId = 2, BinNamesId = 2, BinHashCode = 291972557, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 83, RackId = 4, BayId = 6, LevelId = 3, BinNamesId = 1, BinHashCode = -863513047, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 84, RackId = 4, BayId = 6, LevelId = 3, BinNamesId = 2, BinHashCode = -573098862, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 85, RackId = 4, BayId = 6, LevelId = 4, BinNamesId = 1, BinHashCode = -326151564, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 86, RackId = 4, BayId = 6, LevelId = 4, BinNamesId = 2, BinHashCode = 997413098, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            
            new{Id = 87, RackId = 5, BayId = 1, LevelId = 1, BinNamesId = 1, BinHashCode = 1638846713, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 88, RackId = 5, BayId = 1, LevelId = 1, BinNamesId = 2, BinHashCode = 1543093550, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 89, RackId = 5, BayId = 1, LevelId = 2, BinNamesId = 1, BinHashCode = -1128665772, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 90, RackId = 5, BayId = 1, LevelId = 2, BinNamesId = 2, BinHashCode = 486148647, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 91, RackId = 5, BayId = 1, LevelId = 3, BinNamesId = 1, BinHashCode = -1264708691, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 92, RackId = 5, BayId = 1, LevelId = 3, BinNamesId = 2, BinHashCode = 2026885023, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 93, RackId = 5, BayId = 1, LevelId = 4, BinNamesId = 1, BinHashCode = 979658065, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 94, RackId = 5, BayId = 1, LevelId = 4, BinNamesId = 2, BinHashCode = 1465100942, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 95, RackId = 5, BayId = 2, LevelId = 1, BinNamesId = 1, BinHashCode = -1984800236, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 96, RackId = 5, BayId = 2, LevelId = 1, BinNamesId = 2, BinHashCode = -1216511168, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 97, RackId = 5, BayId = 2, LevelId = 2, BinNamesId = 1, BinHashCode = -456683100, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 98, RackId = 5, BayId = 2, LevelId = 2, BinNamesId = 2, BinHashCode = -317063528, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 99, RackId = 5, BayId = 2, LevelId = 3, BinNamesId = 1, BinHashCode = -87416372, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 100, RackId = 5, BayId = 2, LevelId = 3, BinNamesId = 2, BinHashCode = 411003153, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 101, RackId = 5, BayId = 2, LevelId = 4, BinNamesId = 1, BinHashCode = -1884306233, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 102, RackId = 5, BayId = 2, LevelId = 4, BinNamesId = 2, BinHashCode = -340554057, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 103, RackId = 5, BayId = 3, LevelId = 1, BinNamesId = 1, BinHashCode = -1690893460, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 104, RackId = 5, BayId = 3, LevelId = 1, BinNamesId = 2, BinHashCode = -1153602774, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 105, RackId = 5, BayId = 3, LevelId = 2, BinNamesId = 1, BinHashCode = 1710903346, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 106, RackId = 5, BayId = 3, LevelId = 2, BinNamesId = 2, BinHashCode = 773588751, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 107, RackId = 5, BayId = 3, LevelId = 3, BinNamesId = 1, BinHashCode = -1603994513, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 108, RackId = 5, BayId = 3, LevelId = 3, BinNamesId = 2, BinHashCode = 1282473269, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 109, RackId = 5, BayId = 3, LevelId = 4, BinNamesId = 1, BinHashCode = -57269117, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}, 
            new{Id = 110, RackId = 5, BayId = 3, LevelId = 4, BinNamesId = 2, BinHashCode = 839865094, DateAdded= Convert.ToDateTime("2024-12-10 08:04:17.763916")}
      );

      modelBuilder.Entity<Product>().HasData(
            new{Id = 1, Name = "Pillows Ube-Filled Crackers HA-24gX100", TypeOfPackage = "Carton", Measurement = "47 X 21 X 35" , Weight = Convert.ToDecimal(3.50), DateAdded = DateTime.Now},
            new{Id = 2, Name = "Pillows Chocolate Crackers HA-24gX100", TypeOfPackage = "Carton", Measurement = "47 X 21 X 35" , Weight = Convert.ToDecimal(3.50), DateAdded = DateTime.Now},
            new{Id = 3, Name = "Bread Pan Toasted Garlic 24gX100pcs", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 4, Name = "Bread Pan Cheese & Onion 24gX100pcs", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 5, Name = "Bread Pan Cheese & Onion 24gX100pcs", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 6, Name = "Bread Pan Buttered Toast 24gX100pcs", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 7, Name = "Miggos Sweet Corn Tortilla Chips L28g", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 8, Name = "O-puff Chocolate Cream Filled OWA 3.5g x 24 x 30", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 9, Name = "O-puff Mango Filled OWA 3.5g x 24 x 30", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 10, Name = "O-puff Ube Marshmallow OWA 3.5g x 24 x 30", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 11, Name = "Onion Rings L-16gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 12, Name = "Oishi Prawn Cracker L-24gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 13, Name = "Oishi Potato Fries BBQ LB-21gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 14, Name = "Oishi Potato Fries Cheese LB-21gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 15, Name = "Potato Fries Tomato Ketchup LB-21gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 16, Name = "Oishi Fishda Fish Kropeck LF-22gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 17, Name = "Fish Cracker L-24gx100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 18, Name = "Oishi Sundays Mango Juice 35gx6x20", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 19, Name = "Oishi Sundays Orange Juice 35gx6x20", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 20, Name = "Oishi Sundays Orange-Mango Blends 35gx6x20", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 21, Name = "POTATO FRIES BBQ 50gX50", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 22, Name = "POTATO FRIES CHEESE 50gX50", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 23, Name = "POTATO FRIES KETCHUP FLAVOR 50gX50", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 24, Name = "OISHI PILLOWS CHOCOLATE CRACKERS 150gX20", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 25, Name = "MIGGOS NACHO CHEESE TORTILLA CHIPS L28gX100", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 26, Name = "SELECTA MOO MILK", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 27, Name = "SKYFLAKES", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 28, Name = "ISDALICIOUS FISH CRACKER", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 29, Name = "RICE & CORN CHEESE", TypeOfPackage = "Carton", Measurement = "56 X 24 X 40" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 30, Name = "CHEESE RING 60gX25pcs", TypeOfPackage = "Sack", Measurement = "71 X 42 X 13" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 31, Name = "CHEESE BALL 60gX25pcs", TypeOfPackage = "Sack", Measurement = "71 X 42 X 13" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},          
            new{Id = 32, Name = "GOLDEN SWEET CORN 60gX25pcs", TypeOfPackage = "Sack", Measurement = "71 X 42 X 13" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 33, Name = "FAN MOTOR 24V 10' FAN BASE 10' FAN BLADE", TypeOfPackage = "PCS", Measurement = "60 X 46 X 46" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 34, Name = "CIRCUIT BOARD TS26F CONTROLLER NEW SENSORS CPR WITH O RING FUSE DETECTION BOARD", TypeOfPackage = "PCS", Measurement = "62 X 28 X 16" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 35, Name = "COPPER HOSE BENDABLE", TypeOfPackage = "PCS", Measurement = "39 X 32 X 21" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 36, Name = "RECEIVER DRIER 15NF RECEIVER DRIER 20NF", TypeOfPackage = "PCS", Measurement = "40 X 29 X 20" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 37, Name = "CURTAIN ROD", TypeOfPackage = "PCS", Measurement = "100 X 6 X 4" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 38, Name = "PLASTIC CURTAIN", TypeOfPackage = "PCS", Measurement = "38 X 38 X 23" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 39, Name = "ELIMINATOR FILTER DRIER", TypeOfPackage = "PCS", Measurement = "38 X 38 X 23" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 40, Name = "THERMOSTATIC EXPANSION VALVE 15NF THERMOSTATIC EXPANSION VALVE 20NF", TypeOfPackage = "PCS", Measurement = "40 X 29 X 20" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 41, Name = "TANG PWD JCE STRAWBERRY 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 42, Name = "TANG PWD JCE MANGO 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 43, Name = "TANG PWD JCE I.TEA LEMON 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 44, Name = "TANG PWD JCE GRAPE 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 45, Name = "TANG PWD JCE ORANGE 12/12/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 46, Name = "TANG PWD JCE FOUR SEASON 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 47, Name = "TANG PWD JCE FOUR SEASON 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 48, Name = "OISHI FISH CRACKERS UA 90gX30", TypeOfPackage = "Sack", Measurement = "27 X 40 X 63" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 49, Name = "Miggos Sweet Corn Tortilla Chips UA 105gX30", TypeOfPackage = "Sack", Measurement = "29 X 49 X 66" , Weight = Convert.ToDecimal(3.50), DateAdded =  DateTime.Now},
            new{Id = 50, Name = "DL-2000A DC12V WALL MOUNTED ELECTRIC AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "60.5 X 43 X 17.5" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 51, Name = "DL-2000F1 DC12V WALL MOUNTED AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "73.5 X 55 X 32.5" , Weight = Convert.ToDecimal(25), DateAdded =  DateTime.Now},
            new{Id = 52, Name = "DL-2600A1 DC24V WALL MOUNTED ELECTRIC AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "61 X 42 X 27" , Weight = Convert.ToDecimal(6), DateAdded =  DateTime.Now},
            new{Id = 53, Name = "DL-2600F DC24V WALL MOUNTED AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "73.5 X 55 X 32.5" , Weight = Convert.ToDecimal(24), DateAdded =  DateTime.Now},
            new{Id = 54, Name = "DL-2600FT-BY DC24V WALL MOUNTED AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "78 X 50 X 32" , Weight = Convert.ToDecimal(25), DateAdded =  DateTime.Now},
            new{Id = 55, Name = "DL-1800 DC12V ROOF AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "96 X 80 X 40" , Weight = Convert.ToDecimal(25), DateAdded =  DateTime.Now},
            new{Id = 56, Name = "DL-1800BY DC24V ROOF AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "96 X 80 X 40" , Weight = Convert.ToDecimal(25), DateAdded =  DateTime.Now},
            new{Id = 57, Name = "DL-1800-12V ROOF AIR CONDITIONER", TypeOfPackage = "Carton", Measurement = "96 X 80 X 40" , Weight = Convert.ToDecimal(25), DateAdded =  DateTime.Now},
            new{Id = 58, Name = "Zesto Big 250 Grapes", TypeOfPackage = "Carton", Measurement = "41 X 23 X 17" , Weight = Convert.ToDecimal(10.5), DateAdded =  DateTime.Now},
            new{Id = 59, Name = "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", TypeOfPackage = "Carton", Measurement = "31 X 37 X 21" , Weight = Convert.ToDecimal(0), DateAdded =  DateTime.Now},
            new{Id = 60, Name = "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", TypeOfPackage = "Carton", Measurement = "31 X 37 X 21" , Weight = Convert.ToDecimal(7.5), DateAdded =  DateTime.Now},
            new{Id = 61, Name = "KOPIKO BLANCA POUCH 24X10X30G", TypeOfPackage = "Carton", Measurement = "25 X 36 X 28" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 62, Name = "KOPIKO BLACK 3IN1 POUCH 24X1024X 10 X 30G", TypeOfPackage = "Carton", Measurement = "24 X 43 X 28" , Weight = Convert.ToDecimal(8), DateAdded =  DateTime.Now},
            new{Id = 63, Name = "JUMBO PUSH POP 24 X 12 X 30G", TypeOfPackage = "Carton", Measurement = "30 X 50 X 20" , Weight = Convert.ToDecimal(14.5), DateAdded =  DateTime.Now},
            new{Id = 64, Name = "PUSH POP LOLLIPOP 20 X 20 X 14G", TypeOfPackage = "Carton", Measurement = "17 X 52 X 26" , Weight = Convert.ToDecimal(11.5), DateAdded =  DateTime.Now},
            new{Id = 65, Name = "KOJIE SL CLASSIC SOAP 135G X 24 X 20", TypeOfPackage = "Carton", Measurement = "21 X 24 X 19" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 66, Name = "AJI CRISPY FRY ORIG 24/238G", TypeOfPackage = "Carton", Measurement = "18 X 16 X 32" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 67, Name = "MODESS BODY ADAPT LONGS UT 24/4S", TypeOfPackage = "Carton", Measurement = "18 X 16 X 32" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 68, Name = "MODESS C.SFT LONG W 24/8'S", TypeOfPackage = "Carton", Measurement = "38 X 18 X 37" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 69, Name = "DM PINEAPPLE SLICES 24/432G", TypeOfPackage = "Carton", Measurement = "35 X 18 X 27" , Weight = Convert.ToDecimal(12.5), DateAdded =  DateTime.Now},
            new{Id = 70, Name = "MODESS ALL NIGHT W 24/4'S", TypeOfPackage = "Carton", Measurement = "24 X 18 X 29" , Weight = Convert.ToDecimal(1.5), DateAdded =  DateTime.Now},
            new{Id = 71, Name = "MODESS C.SFT REG MAXI W 12/32/1S", TypeOfPackage = "Carton", Measurement = "48 X 31 X 24" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 72, Name = "TANG PWD JCE LYCHEE 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 73, Name = "FIESTA FRT COCKTL 6/3033G", TypeOfPackage = "Carton", Measurement = "17 X 48 X 32" , Weight = Convert.ToDecimal(20.5), DateAdded =  DateTime.Now},
            new{Id = 74, Name = "TANG PWD JCE APPLE 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 75, Name = "TANG PWD JCE ORANGE-MANGO 144/19G", TypeOfPackage = "Carton", Measurement = "27 X 22 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 76, Name = "SKYFLAKES CRCKR SWCH TSOKOLATE 30/10", TypeOfPackage = "Carton", Measurement = "19 X 49 X 34" , Weight = Convert.ToDecimal(10), DateAdded =  DateTime.Now},
            new{Id = 77, Name = "SKYFLAKES CRCKR SWCH CONDENSADA 30/10", TypeOfPackage = "Carton", Measurement = "19 X 49 X 34" , Weight = Convert.ToDecimal(10), DateAdded =  DateTime.Now},
            new{Id = 78, Name = "SELECTA MOO MILK CHOCO 24/245ML", TypeOfPackage = "Carton", Measurement = "33 X 13 X 17" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 79, Name = "SNOWTIME ICE POPS 15/8/90ML", TypeOfPackage = "Carton", Measurement = "33 X 22 X 27" , Weight = Convert.ToDecimal(11.5), DateAdded =  DateTime.Now},
            new{Id = 80, Name = "PARTY PACK SUPER CRUNCH CHEESE RINGS 370G X 12S", TypeOfPackage = "Carton", Measurement = "37 X 70 X 40" , Weight = Convert.ToDecimal(5.5), DateAdded =  DateTime.Now},
            new{Id = 81, Name = "MUNCHER KID'S CHOICE GREEN PEAS CHICKEN", TypeOfPackage = "Carton", Measurement = "44 X 30 X 39" , Weight = Convert.ToDecimal(13.5), DateAdded =  DateTime.Now},
            new{Id = 82, Name = "Muncher G. Peas Orig 70gX10packsX10pcs", TypeOfPackage = "Carton", Measurement = "40 X 19 X 20" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 83, Name = "Super Q Golden Bihon 15x1KG", TypeOfPackage = "Carton", Measurement = "72 X 40 X 17" , Weight = Convert.ToDecimal(15), DateAdded =  DateTime.Now},
            new{Id = 84, Name = "ZEST-O ORANGE 10X200ML", TypeOfPackage = "Carton", Measurement = "21 X 10 X 15" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 85, Name = "ZEST-O MANGO 10X200ML", TypeOfPackage = "Carton", Measurement = "21 X 10 X 15" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 86, Name = "Cheese Ring Snack Cheese 25x60g", TypeOfPackage = "Carton", Measurement = "84 X 36 X 13" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 87, Name = "Snacku Vegetable Snack 30/50G", TypeOfPackage = "Carton", Measurement = "78 X 33 X 13" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 88, Name = "Maya Cornstarch 12x1kg", TypeOfPackage = "Carton", Measurement = "37 X 34 X 21" , Weight = Convert.ToDecimal(12.5), DateAdded =  DateTime.Now},
            new{Id = 89, Name = "American Gumball 24x40", TypeOfPackage = "Carton", Measurement = "44 X 30 X 21" , Weight = Convert.ToDecimal(4), DateAdded =  DateTime.Now},
            new{Id = 90, Name = "Ordinary Mattress 4x36x75", TypeOfPackage = "Carton", Measurement = "86 X 51 X 39" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 91, Name = "Ordinary Mattress 4x54x75", TypeOfPackage = "Carton", Measurement = "164 X 61 X 33" , Weight = Convert.ToDecimal(2.5), DateAdded =  DateTime.Now},
            new{Id = 92, Name = "Jumbo Rack 4 layer", TypeOfPackage = "Carton", Measurement = "54 X 98 X 77" , Weight = Convert.ToDecimal(11.5), DateAdded =  DateTime.Now},
            new{Id = 93, Name = "1339 DM KTCHP TOM(ORG) 12/567G", TypeOfPackage = "Carton", Measurement = "30 X 23 X 26" , Weight = Convert.ToDecimal(11), DateAdded =  DateTime.Now},
            new{Id = 94, Name = "1339 DM KTCHP TOM(ORG) 12/567G", TypeOfPackage = "Carton", Measurement = "30 X 23 X 26" , Weight = Convert.ToDecimal(11), DateAdded =  DateTime.Now},
            new{Id = 95, Name = "30308 MAXX CANDY DALANDAN 40/50S", TypeOfPackage = "Carton", Measurement = "41 X 32 X 26" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 96, Name = "30308 MAXX CANDY CHERRY 40/50S", TypeOfPackage = "Carton", Measurement = "41 X 32 X 26" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 97, Name = "TODAY'S MIXED FRUIT 6/2.9L", TypeOfPackage = "Carton", Measurement = "48 X 31 X 17" , Weight = Convert.ToDecimal(20), DateAdded =  DateTime.Now},
            new{Id = 98, Name = "965 COL.MONAMI STRAW CRM 40/50'S", TypeOfPackage = "Carton", Measurement = "43 X 29 X 26" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 99, Name = "ABSOLUTE DISTILLED WATER 3/5000ML", TypeOfPackage = "Carton", Measurement = "37 X 15 X 28" , Weight = Convert.ToDecimal(15), DateAdded =  DateTime.Now},
            new{Id = 100, Name = "ABSOLUTE DISTILLED WATER 3/6000ML", TypeOfPackage = "Carton", Measurement = "44 X 13 X 33" , Weight = Convert.ToDecimal(19), DateAdded =  DateTime.Now},
            new{Id = 101, Name = "ABSOLUTE DISTILLED WATER 4/4000ML", TypeOfPackage = "Carton", Measurement = "29 X 24 X 30" , Weight = Convert.ToDecimal(16), DateAdded =  DateTime.Now},
            new{Id = 102, Name = "AJINAMOTO GINISA MIX 48/100G", TypeOfPackage = "Carton", Measurement = "30 X 22 X 17" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 103, Name = "AJINAMOTO GINISA MIX 54/16/8G", TypeOfPackage = "Carton", Measurement = "40 X 25 X 24" , Weight = Convert.ToDecimal(8), DateAdded =  DateTime.Now},
            new{Id = 104, Name = "AJINAMOTO VETSIN BLUE 48/250G", TypeOfPackage = "Carton", Measurement = "39 X 28 X 15" , Weight = Convert.ToDecimal(13), DateAdded =  DateTime.Now},
            new{Id = 105, Name = "AJINAMOTO VETSIN RED 8X12X100G", TypeOfPackage = "Carton", Measurement = "35 X 22 X 18", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now },
            new{Id = 106, Name = "CHEESE RING SNACK CHEESE 30/25G", TypeOfPackage = "Carton", Measurement = "77 X 31 X 13" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 107, Name = "DATU PUTI VINEGAR PCON 4/1GAL", TypeOfPackage = "Carton", Measurement = "29 X 30 X 32" , Weight = Convert.ToDecimal(16), DateAdded =  DateTime.Now},
            new{Id = 108, Name = "DATU PUTI VINEGAR 8/1.893", TypeOfPackage = "Carton", Measurement = "44 X 24 X 31" , Weight = Convert.ToDecimal(16), DateAdded =  DateTime.Now},
            new{Id = 109, Name = "FIBISCO COOKIES CHOCO CHIP 36/200G", TypeOfPackage = "Carton", Measurement = "53 X 40 X 20" , Weight = Convert.ToDecimal(8), DateAdded =  DateTime.Now},
            new{Id = 110, Name = "FIBISCO COOKIES CHOCO CHIP 36/200G", TypeOfPackage = "Carton", Measurement = "53 X 40 X 20" , Weight = Convert.ToDecimal(8), DateAdded =  DateTime.Now},
            new{Id = 111, Name = "FITA CRACKER SINGLES 20/15/30G", TypeOfPackage = "Carton", Measurement = "51 X 38 X 82" , Weight = Convert.ToDecimal(10), DateAdded =  DateTime.Now},
            new{Id = 112, Name = "HAPPY TIME BISCUIT ASSORTMENT 4/1.5K", TypeOfPackage = "Carton", Measurement = "48 X 24 X 31" , Weight = Convert.ToDecimal(8), DateAdded =  DateTime.Now},
            new{Id = 113, Name = "KNR MIX SNGNG ORIG 12/12/22G", TypeOfPackage = "Carton", Measurement = "25 X 25 X 20" , Weight = Convert.ToDecimal(4), DateAdded =  DateTime.Now},
            new{Id = 114, Name = "KNR SOUP CRAB & CORN 72/37G", TypeOfPackage = "Carton", Measurement = "34 X 14 X 20" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 115, Name = "MAGGI MAGIC SARAP SEASONING 60/16/8G", TypeOfPackage = "Carton", Measurement = "29 X 30 X 35" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 116, Name = "MAGGI MAGIC SARAP SEASONING 60/16/8G", TypeOfPackage = "Carton", Measurement = "29 X 30 X 35" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 117, Name = "MCCORMICK BLACK PEPPER GRND 12/35G", TypeOfPackage = "Carton", Measurement = "18 X 14 X 12" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 118, Name = "OISHI CHEESE CLUBS 100X23G", TypeOfPackage = "Carton", Measurement = "55 X 41 X 19" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 119, Name = "OISHI PILLOWS CHOCO 100/38G", TypeOfPackage = "Carton", Measurement = "57 X 24 X 38" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 120, Name = "OISHI PILLOWS UBE 100/38G", TypeOfPackage = "Carton", Measurement = "57 X 24 X 38" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 121, Name = "OREO SND.CKIE CHOCO 12/9/27G", TypeOfPackage = "Carton", Measurement = "30 X 18 X 26" , Weight = Convert.ToDecimal(4), DateAdded =  DateTime.Now},
            new{Id = 122, Name = "QUEEN BAKING SODA 48/125G", TypeOfPackage = "Carton", Measurement = "41 X 14 X 17" , Weight = Convert.ToDecimal(6.5), DateAdded =  DateTime.Now},
            new{Id = 123, Name = "WHITE KING FIESTA ELBOW MAC 12/1KG", TypeOfPackage = "Carton", Measurement = "41 X 31 X 22" , Weight = Convert.ToDecimal(12), DateAdded =  DateTime.Now},
            new{Id = 124, Name = "WHITE KING FIESTA ELBOW MAC 12/1KG", TypeOfPackage = "Carton", Measurement = "41 X 31 X 22" , Weight = Convert.ToDecimal(12), DateAdded =  DateTime.Now},
            new{Id = 125, Name = "VIVA CARAMEL CANDY 20/100'S", TypeOfPackage = "Carton", Measurement = "40 X 26 X 19" , Weight = Convert.ToDecimal(10), DateAdded =  DateTime.Now},
            new{Id = 126, Name = "UFC BANANA CATSUP 24/320G", TypeOfPackage = "Carton", Measurement = "37 X 25 X 21" , Weight = Convert.ToDecimal(13), DateAdded =  DateTime.Now},
            new{Id = 127, Name = "SUPER Q GOLDEN BIHON 60/227G", TypeOfPackage = "Carton", Measurement = "44 X 18 X 69" , Weight = Convert.ToDecimal(14), DateAdded =  DateTime.Now},
            new{Id = 128, Name = "SUPER Q GOLDEN BIHON 30/500 G", TypeOfPackage = "Carton", Measurement = "69 X 38 X 18" , Weight = Convert.ToDecimal(16), DateAdded =  DateTime.Now},
            new{Id = 129, Name = "STIK-O STRAW WATER JR 12/380G", TypeOfPackage = "Carton", Measurement = "42 X 33 X 18" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 130, Name = "STIK-O UBE WATER JR 12/380G", TypeOfPackage = "Carton", Measurement = "42 X 33 X 18" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 131, Name = "STIK-O CHOCO WATER JR 12/380G", TypeOfPackage = "Carton", Measurement = "42 X 33 X 18" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 132, Name = "ROYAL SPAGHETTI 18/900G", TypeOfPackage = "Carton", Measurement = "27 X 26 X 29" , Weight = Convert.ToDecimal(16), DateAdded =  DateTime.Now},
            new{Id = 133, Name = "SKYFLAKES REG 30/10/25G", TypeOfPackage = "Carton", Measurement = "50 X 37 X 28" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 134, Name = "STIK-O CHOCO WAFER MINI 30/60G", TypeOfPackage = "Carton", Measurement = "31 X 20 X 17" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 135, Name = "OISHI PRAWN CRACKER 100/24G", TypeOfPackage = "Carton", Measurement = "43 X 18 X 54" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 136, Name = "OISHI PRAWN CRACKER 30/95G", TypeOfPackage = "Carton", Measurement = "68 X 37 X 28" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 137, Name = "OISHI PRAWN CRACKER 50/60G", TypeOfPackage = "Carton", Measurement = "56 X 35 X 40" , Weight = Convert.ToDecimal(2), DateAdded =  DateTime.Now},
            new{Id = 138, Name = "SNACKU VEGETABLE SNACK 25/60G", TypeOfPackage = "Carton", Measurement = "31 X 20 X 17" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 139, Name = "SWEET CORN SNACK 25/60G", TypeOfPackage = "Carton", Measurement = "73 X 33 X 13" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 140, Name = "SWEET CORN SNACK 30/25", TypeOfPackage = "Carton", Measurement = "31 X 13 X 70" , Weight = Convert.ToDecimal(1), DateAdded =  DateTime.Now},
            new{Id = 141, Name = "ZONROX BLEACH FRSH SCNT 24/1000ML", TypeOfPackage = "Carton", Measurement = "52 X 36 X 26" , Weight = Convert.ToDecimal(27), DateAdded =  DateTime.Now},
            new{Id = 142, Name = "ZONROX BLEACH ORIGINAL 24/1000ML", TypeOfPackage = "Carton", Measurement = "52 X 36 X 26" , Weight = Convert.ToDecimal(27), DateAdded =  DateTime.Now},
            new{Id = 143, Name = "ZONROX BLEACH FLORAL 24/1000ML", TypeOfPackage = "Carton", Measurement = "52 X 36 X 26" , Weight = Convert.ToDecimal(27), DateAdded =  DateTime.Now},
            new{Id = 144, Name = "ZONROX BLEACH COLORSAFE 24/900ML", TypeOfPackage = "Carton", Measurement = "52 X 36 X 26" , Weight = Convert.ToDecimal(27), DateAdded =  DateTime.Now},
            new{Id = 145, Name = "MENTOS CANDY TROPICAL MIX 40/50", TypeOfPackage = "Carton", Measurement = "32 X 26 X 32" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 146, Name = "KJSN SOAP SKIN LGHTNNG 24/2/135G", TypeOfPackage = "Carton", Measurement = "29 X 15 X 23" , Weight = Convert.ToDecimal(5), DateAdded =  DateTime.Now},
            new{Id = 147, Name = "TIDE BAR NAT FRSH 36/380G", TypeOfPackage = "Carton", Measurement = "34 X 30 X 11" , Weight = Convert.ToDecimal(14), DateAdded =  DateTime.Now},
            new{Id = 148, Name = "SURF BAR W/FBCN BLOSFRSH", TypeOfPackage = "Carton", Measurement = "31 X 22 X 15" , Weight = Convert.ToDecimal(13), DateAdded =  DateTime.Now},
            new{Id = 149, Name = "KJSN SOAP SKIN LGHTNNG 48/2/65G", TypeOfPackage = "Carton", Measurement = "22 X 19 X 24" , Weight = Convert.ToDecimal(6), DateAdded =  DateTime.Now},
            new{Id = 150, Name = "CHARMEE S.NPKN A.FLW D.NET NW 36X8", TypeOfPackage = "Carton", Measurement = "36 X 33 X 25" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 151, Name = "CHARMEE S.NPKN A.FLW D.NET W 36X8", TypeOfPackage = "Carton", Measurement = "36 X 33 X 25" , Weight = Convert.ToDecimal(3), DateAdded =  DateTime.Now},
            new{Id = 152, Name = "NATURE SPRING 10L PURE", TypeOfPackage = "Carton", Measurement = "39 X 19 X 42" , Weight = Convert.ToDecimal(20), DateAdded =  DateTime.Now},
            new{Id = 153, Name = "NATURE SPRING 10L DISTILLED", TypeOfPackage = "Carton", Measurement = "39 X 19 X 42" , Weight = Convert.ToDecimal(20), DateAdded =  DateTime.Now},
            new{Id = 154, Name = "KENDI MINT CANDY 60/50", TypeOfPackage = "Carton", Measurement = "50 X 41 X 19" , Weight = Convert.ToDecimal(14), DateAdded =  DateTime.Now},
            new{Id = 155, Name = "AJI CRISPY FRY ORIGINAL 13/14/62", TypeOfPackage = "Carton", Measurement = "43 X 20 X 25" , Weight = Convert.ToDecimal(12), DateAdded =  DateTime.Now},
            new{Id = 156, Name = "MIRINDA ORANGE PET BOTTLE 12/1.5L", TypeOfPackage = "Carton", Measurement = "32 X 22 X 34" , Weight = Convert.ToDecimal(19), DateAdded =  DateTime.Now},
            new{Id = 157, Name = "108080 SPRITE REG PET BOT 12/1.5L", TypeOfPackage = "Carton", Measurement = "35 X 26 X 22" , Weight = Convert.ToDecimal(19), DateAdded =  DateTime.Now},
            new{Id = 158, Name = "AJINAMOTO GINISA MIX 120/40G", TypeOfPackage = "Carton", Measurement = "46 X 30 X 15" , Weight = Convert.ToDecimal(6), DateAdded =  DateTime.Now},
            new{Id = 159, Name = "PEPSI REG PET BOTTLE 12/1.5L", TypeOfPackage = "Carton", Measurement = "32 X 22 X 34" , Weight = Convert.ToDecimal(19), DateAdded =  DateTime.Now},
            new{Id = 160, Name = "MENTOS CANDY MINT BAG 40/50", TypeOfPackage = "Carton", Measurement = "38 X 30 X 24" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 161, Name = "VIVA CARAMEL CANDY 60/50", TypeOfPackage = "Carton", Measurement = "50 X 41 X 19" , Weight = Convert.ToDecimal(14), DateAdded =  DateTime.Now},
            new{Id = 162, Name = "MOUNTAIN DEW PET BOTTLE 12/1.5L", TypeOfPackage = "Carton", Measurement = "32 X 22 X 34" , Weight = Convert.ToDecimal(19), DateAdded =  DateTime.Now},
            new{Id = 163, Name = "STING ENERGY DRINK STRAWBERRY 24/320", TypeOfPackage = "Carton", Measurement = "33 X 16 X 21" , Weight = Convert.ToDecimal(9), DateAdded =  DateTime.Now},
            new{Id = 164, Name = "PEPSI REG PET BOT 24/500ML", TypeOfPackage = "Carton", Measurement = "40 X 23 X 22" , Weight = Convert.ToDecimal(12), DateAdded =  DateTime.Now},
            new{Id = 165, Name = "SUPER Q PALABOK 12/500G", TypeOfPackage = "Carton", Measurement = "72 X 40 X 17" , Weight = Convert.ToDecimal(6), DateAdded =  DateTime.Now},
            new{Id = 166, Name = "LORINS PATIS PLASTIC 12/1000ML", TypeOfPackage = "Carton", Measurement = "33 X 27 X 29" , Weight = Convert.ToDecimal(15), DateAdded =  DateTime.Now},
            new{Id = 167, Name = "LORINS PATIS PLASTIC 24/350ML", TypeOfPackage = "Carton", Measurement = "37 X 26 X 19" , Weight = Convert.ToDecimal(11), DateAdded =  DateTime.Now},
            new{Id = 168, Name = "AJI CRISPY FRY GARLIC 13/14/62G", TypeOfPackage = "Carton", Measurement = "43 X 20 X 25" , Weight = Convert.ToDecimal(12), DateAdded =  DateTime.Now},
            new{Id = 169, Name = "WHITE RABBIT CANDY 60/50", TypeOfPackage = "Carton", Measurement = "50 X 41 X 19" , Weight = Convert.ToDecimal(14), DateAdded =  DateTime.Now},
            new{Id = 170, Name = "RICOA FLAT TOPS 12/100", TypeOfPackage = "Carton", Measurement = "39 X 31 X 21" , Weight = Convert.ToDecimal(7), DateAdded =  DateTime.Now},
            new{Id = 171, Name = "SURF BAR KALAMANSI 36/360G", TypeOfPackage = "Carton", Measurement = "30 X 22 X 17", Weight = Convert.ToDecimal(12.5), DateAdded = DateTime.Now},
            new{Id = 172, Name = "ZEST-O BIG 250 APPLE 10/250ML", TypeOfPackage = "Carton", Measurement = "32 X 10 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 173, Name = "ZEST-O BIG 250 GRAPE 10/250ML", TypeOfPackage = "Carton", Measurement = "32 X 10 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 174, Name = "ZEST-O BIG 250 ORANGE 10/250ML", TypeOfPackage = "Carton", Measurement = "32 X 10 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 175, Name = "ZEST-O BIG MANGO 10/250ML", TypeOfPackage = "Carton", Measurement = "32 X 10 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 176, Name = "IODIZED SALT 1KG", TypeOfPackage = "Carton", Measurement = "32 X 27 X 20", Weight = Convert.ToDecimal(20), DateAdded = DateTime.Now},
            new{Id = 177, Name = "IODIZED SALT 500G", TypeOfPackage = "Carton", Measurement = "32 X 27 X 20", Weight = Convert.ToDecimal(19), DateAdded = DateTime.Now},
            new{Id = 178, Name = "LASAP SINIGANG MIX 20G", TypeOfPackage = "Carton", Measurement = "30 X 14 X 13", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 179, Name = "LASAP VETSIN 100G", TypeOfPackage = "Carton", Measurement = "28 X 28 X 19", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 180, Name = "LASAP VETSIN 100G", TypeOfPackage = "Carton", Measurement = "28 X 28 X 19", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 181, Name = "LASAP SINIGANG MIX W/GABI 22G", TypeOfPackage = "Carton", Measurement = "33 X 19 X 15", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 182, Name = "LASAP OYSTER SAUCE 170 G", TypeOfPackage = "Carton", Measurement = "32 X 22 X 17", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 183, Name = "LASAP KARE KARE MIX 75G", TypeOfPackage = "Carton", Measurement = "32 X 22 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 184, Name = "LASAP TOCINO MIX", TypeOfPackage = "Carton", Measurement = "30 X 14 X 13", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 185, Name = "LASAP BBQ MIX 50G", TypeOfPackage = "Carton", Measurement = "30 X 14 X 13", Weight = Convert.ToDecimal(1), DateAdded = DateTime.Now},
            new{Id = 186, Name = "REGENT TEMPURA SHRIMP 25/100G", TypeOfPackage = "Carton", Measurement = "59 X 36 X 40", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 187, Name = "REGENT LABSTER 25/100G", TypeOfPackage = "Carton", Measurement = "59 X 36 X 40", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 188, Name = "REGENT ISDALICIOUS 25/85G", TypeOfPackage = "Carton", Measurement = "59 X 36 X 40", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 189, Name = "REGENT UBE CAKE 8/10'S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 190, Name = "REGENT SAND CAKE MELON 8/10S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 191, Name = "REGENT MOCHA CAKE 8/10'S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 192, Name = "REGENT JAPANESE UBE CAKE 34G", TypeOfPackage = "Carton", Measurement = "44 X 27 X 22", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 193, Name = "REGENT JAPANESE CHOKORETO CAKE 34G", TypeOfPackage = "Carton", Measurement = "44 X 27 X 22", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 194, Name = "REGENT JAPANESE CHEESECAKE 34G", TypeOfPackage = "Carton", Measurement = "44 X 27 X 22", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 195, Name = "REGENT MOCHI MANGO 240G", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 196, Name = "REGENT MOCHI UBE 240 G", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 197, Name = "REGENT BUKO PANDAN 240G", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 198, Name = "REGENT MOCHI ASSORTED", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 199, Name = "REGENT MOCHI BLACK SESAME 240G", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 200, Name = "REGENT MOCHI BLACK SESAME 240G", TypeOfPackage = "Carton", Measurement = "34 X 27 X 14", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 201, Name = "CRIS P'S SEAWEED 60G", TypeOfPackage = "Carton", Measurement = "50 X 38 X 26", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 202, Name = "CRIS P'S SAL VINEGAR 60G", TypeOfPackage = "Carton", Measurement = "50 X 38 X 26", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 203, Name = "CRIS P'S CHEESE", TypeOfPackage = "Carton", Measurement = "50 X 38 X 26", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 204, Name = "POTATO CRACKERS", TypeOfPackage = "Carton", Measurement = "40 X 21 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 205, Name = "KING CRAB", TypeOfPackage = "Carton", Measurement = "61 X 39 X 41", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 206, Name = "GOLDEN SWEET CORN", TypeOfPackage = "Carton", Measurement = "60 X 30 X 33", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 207, Name = "CHEESE RING JALAPENO", TypeOfPackage = "Carton", Measurement = "60 X 30 X 33", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 208, Name = "CHEESE RING CHEESE", TypeOfPackage = "Carton", Measurement = "60 X 30 X 33", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 209, Name = "FRENCH FRIES", TypeOfPackage = "Carton", Measurement = "61 X 39 X 41", Weight = Convert.ToDecimal(5), DateAdded = DateTime.Now},
            new{Id = 210, Name = "SHRIMP FRITTERS", TypeOfPackage = "Carton", Measurement = "61 X 39 X 41", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 211, Name = "MOBY CARAMEL 90G", TypeOfPackage = "Carton", Measurement = "54 X 35 X 38", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 212, Name = "CHEESE IT CHEESE 60G", TypeOfPackage = "Carton", Measurement = "64 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 213, Name = "MOBY CHOCOLATE CHIPS 60G", TypeOfPackage = "Carton", Measurement = "63 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 214, Name = "MOBY CARAMEL PUFFS 60G", TypeOfPackage = "Carton", Measurement = "63 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 215, Name = "MOBY CHOCOLATE 25G", TypeOfPackage = "Carton", Measurement = "63 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 216, Name = "MOBY CARAMEL 25G", TypeOfPackage = "Carton", Measurement = "63 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 217, Name = "MOBY CHOCO CUM CHOC BU", TypeOfPackage = "Carton", Measurement = "63 X 46 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 218, Name = "LOADED CHOCO FILLED 65G", TypeOfPackage = "Carton", Measurement = "58 X 48 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 219, Name = "LOADED WHITE CHOCO 65G", TypeOfPackage = "Carton", Measurement = "58 X 48 X 18", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 220, Name = "LOADED WHITE CHOCO 32G", TypeOfPackage = "Carton", Measurement = "56 X 36 X 38", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 221, Name = "LOADED WHITE CHOCO 32G", TypeOfPackage = "Carton", Measurement = "56 X 36 X 38", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 222, Name = "LOADED CHOCO 32G", TypeOfPackage = "Carton", Measurement = "56 X 36 X 38", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 223, Name = "LOADED CHOCO 32G", TypeOfPackage = "Carton", Measurement = "56 X 36 X 38", Weight = Convert.ToDecimal(3), DateAdded = DateTime.Now},
            new{Id = 224, Name = "TOMI SWEET CORN 110G", TypeOfPackage = "Carton", Measurement = "46 X 32 X 52", Weight = Convert.ToDecimal(6), DateAdded = DateTime.Now},
            new{Id = 225, Name = "TOMI SWEET CORN 110G", TypeOfPackage = "Carton", Measurement = "46 X 32 X 52", Weight = Convert.ToDecimal(6), DateAdded = DateTime.Now},
            new{Id = 226, Name = "REGENT STRAWBERRY CAKE 8/10S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 227, Name = "REGENT PANDAN CAKE 8/10S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 228, Name = "REGENT ASSORTED CAKE 8/10S", TypeOfPackage = "Carton", Measurement = "37 X 35 X 17", Weight = Convert.ToDecimal(2), DateAdded = DateTime.Now},
            new{Id = 229, Name = "REGENT BANANA CAKE 34G", TypeOfPackage = "Carton", Measurement = "44 X 27 X 22", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 230, Name = "REGENT BELGIAN WAFFLE 30G", TypeOfPackage = "Carton", Measurement = "46 X 30 X 15", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 231, Name = "REGENT BELGIAN CHOCO", TypeOfPackage = "Carton", Measurement = "46 X 30 X 15", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 232, Name = "REGENT BELGIAN CHOCO", TypeOfPackage = "Carton", Measurement = "46 X 30 X 15", Weight = Convert.ToDecimal(4), DateAdded = DateTime.Now},
            new{Id = 233, Name = "FLORENCE MACAPUNO 24/12OZ", TypeOfPackage = "Carton", Measurement = "38 X 30 X 18", Weight = Convert.ToDecimal(12), DateAdded = DateTime.Now},
            new{Id = 234, Name = "FLORENCE JACKFRUIT 24/12OZ", TypeOfPackage = "Carton", Measurement = "38 X 30 X 18", Weight = Convert.ToDecimal(12), DateAdded = DateTime.Now},
            new{Id = 235, Name = "FLORENCE KAONG RED 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 236, Name = "FLORENCE NATA DE COCO WHITE 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 237, Name = "FLORENCE NATA DE COCO GREEN 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 238, Name = "FLORENCE NATA DE COCO RED 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 240, Name = "FLORENCE JACKFRUIT 24X12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 241, Name = "FLORENCE PURPLE YAM 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 242, Name = "FLORENCE PURPLE YAM 24/12OZ", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 243, Name = "FLORENCE NATA DE COCO WHITE 12/24OZ", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 244, Name = "FLORENCE NATA DE COCO GREEN 12/24OZ", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 245, Name = "FLORENCE NATA DE COCO RED 12/24OZ", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 246, Name = "FLORENCE SALTED SHRIMP 24/340G", TypeOfPackage = "Carton", Measurement = "42 X 32 X 15", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 247, Name = "FLORENCE SAU SHRIMP SWEET", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 248, Name = "FLORENCE SAU SHRIMP REGULAR", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 249, Name = "FLORENCE SAU SHRIMP SPICY", TypeOfPackage = "Carton", Measurement = "40 X 27 X 13", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 250, Name = "FLORENCE BAGOONG BALAYAN", TypeOfPackage = "Carton", Measurement = "39 X 28 X 13", Weight = Convert.ToDecimal(14), DateAdded = DateTime.Now},
            new{Id = 251, Name = "ADORABLE CREAM BAR CHOCO", TypeOfPackage = "Carton", Measurement = "58 X 34 X 38", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 252, Name = "ADORABLE CREAM BAR MATHCA", TypeOfPackage = "Carton", Measurement = "58 X 34 X 38", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 253, Name = "ADORABLE CREAM BAR STRAWBERRY", TypeOfPackage = "Carton", Measurement = "58 X 34 X 38", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 254, Name = "MONIEGOLD TAMARIND CHEWY 150G", TypeOfPackage = "Carton", Measurement = "36 X 44 X 23", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 255, Name = "MONIEGOLD TAMARIND CHEWY 150G", TypeOfPackage = "Carton", Measurement = "36 X 44 X 23", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 256, Name = "MONIEGOLD TAMARIND CHEWY 80G", TypeOfPackage = "Carton", Measurement = "36 X 44 X 23", Weight = Convert.ToDecimal(16), DateAdded = DateTime.Now},
            new{Id = 257, Name = "COCONUT ENERGY BAR NUTS 24/400", TypeOfPackage = "Carton", Measurement = "53 X 34 X 30", Weight = Convert.ToDecimal(10), DateAdded = DateTime.Now},
            new{Id = 258, Name = "COCONUT BLAST ICECREAM CHOCO 24/300", TypeOfPackage = "Carton", Measurement = "54 X 36 X 16", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 259, Name = "COCONUT BLAST ICECREAM STRAWBERRY 24/300", TypeOfPackage = "Carton", Measurement = "54 X 36 X 16", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 260, Name = "COCO CREAM BAR CHOCO 24/300", TypeOfPackage = "Carton", Measurement = "54 X 36 X 16", Weight = Convert.ToDecimal(8), DateAdded = DateTime.Now},
            new{Id = 261, Name = "BIG 250 APPLE", TypeOfPackage = "Carton", Measurement = "41 X 24 X 17", Weight = Convert.ToDecimal(10.5), DateAdded = DateTime.Now},
            new{Id = 262, Name = "BIG 250 GRAPE", TypeOfPackage = "Carton", Measurement = "41 X 24 X 17", Weight = Convert.ToDecimal(10.5), DateAdded = DateTime.Now},
            new{Id = 263, Name = "BIG 250 ORANGE", TypeOfPackage = "Carton", Measurement = "41 X 24 X 17", Weight = Convert.ToDecimal(10.5), DateAdded = DateTime.Now}

      );

      modelBuilder.Entity<Pallet>().HasData(
            new
            {
                  Id = 1, WarehouseId = 1, PalletNumber = 1, PalletHashCode = -33700796, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-01-25 01:53:04.220690"),
            },

            new
            {
                  Id = 2, WarehouseId = 1, PalletNumber = 2, PalletHashCode = 554322328, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-01-25 02:00:59.445116"),
            },

            new
            {
                  Id = 3, WarehouseId = 1, PalletNumber = 3, PalletHashCode = -1258735642, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-01-25 02:11:15.640639"),
            },

            new
            {
                  Id = 4, WarehouseId = 1, PalletNumber = 4, PalletHashCode = 1639556679, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:50:00.627337"),
            },

            new
            {
                  Id = 5, WarehouseId = 1, PalletNumber = 5, PalletHashCode = -389457843, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:53:51.126387"),
            },

            new
            {
                  Id = 7, WarehouseId = 1, PalletNumber = 6, PalletHashCode = 1698320526, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:56:40.703606"),
            },

            new
            {
                  Id = 8, WarehouseId = 1, PalletNumber = 7, PalletHashCode = 448084449, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:56:41.223470"),
            },

            new
            {
                  Id = 10, WarehouseId = 1, PalletNumber = 8, PalletHashCode = 82261761, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:58:08.366758"),
            },

            new
            {
                  Id = 11, WarehouseId = 1, PalletNumber = 9, PalletHashCode = -987980297, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 05:58:09.871657"),
            },

            new
            {
                  Id = 13, WarehouseId = 1, PalletNumber = 10, PalletHashCode = 940111660, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 06:05:10.996564"),
            },

            new
            {
                  Id = 14, WarehouseId = 1, PalletNumber = 11, PalletHashCode = 1045470907, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 06:05:48.030424"),
            },

            new
            {
                  Id = 15, WarehouseId = 1, PalletNumber = 12, PalletHashCode = 883864395, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:37:46.701118"),
            },

            new
            {
                  Id = 16, WarehouseId = 1, PalletNumber = 13, PalletHashCode = -2017262582, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:39:07.408113"),
            },

            new
            {
                  Id = 17, WarehouseId = 1, PalletNumber = 14, PalletHashCode = 52399103, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:39:29.391338"),
            },

            new
            {
                  Id = 18, WarehouseId = 1, PalletNumber = 15, PalletHashCode = 213701906, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:02.375254"),
            },

            new
            {
                  Id = 19, WarehouseId = 1, PalletNumber = 16, PalletHashCode = 688679917, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:29.569180"),
            },

            new
            {
                  Id = 20, WarehouseId = 1, PalletNumber = 17, PalletHashCode = 1124358483, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:33.428197"),
            },

            new
            {
                  Id = 21, WarehouseId = 1, PalletNumber = 18, PalletHashCode = -200130887, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:33.828776"),
            },

            new
            {
                  Id = 22, WarehouseId = 1, PalletNumber = 19, PalletHashCode = 1861152145, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:34.822847"),
            },

            new
            {
                  Id = 23, WarehouseId = 1, PalletNumber = 20, PalletHashCode = -780089336, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:36.287733"),
            },

            new
            {
                  Id = 24, WarehouseId = 1, PalletNumber = 21, PalletHashCode = -898088727, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:36.920523"),
            },

            new
            {
                  Id = 25, WarehouseId = 1, PalletNumber = 22, PalletHashCode = -1301624443, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:43.742178"),
            },

            new
            {
                  Id = 26, WarehouseId = 1, PalletNumber = 23, PalletHashCode = 2126330677, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:44.597598"),
            },

            new
            {
                  Id = 27, WarehouseId = 1, PalletNumber = 24, PalletHashCode = -2027656597, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:45.152881"),
            },

            new
            {
                  Id = 28, WarehouseId = 1, PalletNumber = 25, PalletHashCode = 298456068, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:45.433757"),
            },

            new
            {
                  Id = 29, WarehouseId = 1, PalletNumber = 26, PalletHashCode = 1310428199, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:46.487258"),
            },

            new
            {
                  Id = 30, WarehouseId = 1, PalletNumber = 27, PalletHashCode = -1430758289, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:47.289600"),
            },

            new
            {
                  Id = 31, WarehouseId = 1, PalletNumber = 28, PalletHashCode = -1062054023, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:49.138692"),
            },

            new
            {
                  Id = 32, WarehouseId = 1, PalletNumber = 29, PalletHashCode = 830267492, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:49.216668"),
            },

            new
            {
                  Id = 33, WarehouseId = 1, PalletNumber = 30, PalletHashCode = 947622953, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:50.794793"),
            },

            new
            {
                  Id = 34, WarehouseId = 1, PalletNumber = 31, PalletHashCode = 1470711854, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:52.247983"),
            },

            new
            {
                  Id = 35, WarehouseId = 1, PalletNumber = 32, PalletHashCode = -1146058639, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-02-13 07:40:53.529229"),
            },

            new
            {
                  Id = 398, WarehouseId = 1, PalletNumber = 33, PalletHashCode = 1322963265, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:21.701301"),
            },

            new
            {
                  Id = 399, WarehouseId = 1, PalletNumber = 34, PalletHashCode = 1928472044, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:23.937172"),
            },

            new
            {
                  Id = 400, WarehouseId = 1, PalletNumber = 35, PalletHashCode = -988118190, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:24.940865"),
            },

            new
            {
                  Id = 401, WarehouseId = 1, PalletNumber = 36, PalletHashCode = -1775459348, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:25.724787"),
            },

            new
            {
                  Id = 402, WarehouseId = 1, PalletNumber = 37, PalletHashCode = -1648659206, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:27.496120"),
            },

            new
            {
                  Id = 403, WarehouseId = 1, PalletNumber = 38, PalletHashCode = 987426499, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-04-08 01:39:28.498651"),
            },

            new
            {
                  Id = 404, WarehouseId = 1, PalletNumber = 39, PalletHashCode = -818280427, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 02:06:41.344959"),
            },

            new
            {
                  Id = 405, WarehouseId = 1, PalletNumber = 40, PalletHashCode = 1728123643, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 02:06:42.565409"),
            },

            new
            {
                  Id = 406, WarehouseId = 1, PalletNumber = 41, PalletHashCode = -1544750712, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 02:06:43.276430"),
            },

            new
            {
                  Id = 407, WarehouseId = 1, PalletNumber = 42, PalletHashCode = 2067686016, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:41.725459"),
            },

            new
            {
                  Id = 408, WarehouseId = 1, PalletNumber = 43, PalletHashCode = -1158230228, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:42.666285"),
            },

            new
            {
                  Id = 409, WarehouseId = 1, PalletNumber = 44, PalletHashCode = 875334534, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:43.329667"),
            },

            new
            {
                  Id = 410, WarehouseId = 1, PalletNumber = 45, PalletHashCode = 1121125081, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:43.881814"),
            },

            new
            {
                  Id = 411, WarehouseId = 1, PalletNumber = 46, PalletHashCode = -1251831711, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:44.516308"),
            },

            new
            {
                  Id = 412, WarehouseId = 1, PalletNumber = 47, PalletHashCode = 1844250616, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:45.119870"),
            },

            new
            {
                  Id = 413, WarehouseId = 1, PalletNumber = 48, PalletHashCode = -638388577, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:45.745447"),
            },

            new
            {
                  Id = 414, WarehouseId = 1, PalletNumber = 49, PalletHashCode = 1232753550, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:46.289857"),
            },

            new
            {
                  Id = 415, WarehouseId = 1, PalletNumber = 50, PalletHashCode = 968628869, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:46.921270"),
            },

            new
            {
                  Id = 416, WarehouseId = 1, PalletNumber = 51, PalletHashCode = -541687618, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:47.531973"),
            },

            new
            {
                  Id = 417, WarehouseId = 1, PalletNumber = 52, PalletHashCode = -1006330990, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:48.241162"),
            },

            new
            {
                  Id = 418, WarehouseId = 1, PalletNumber = 53, PalletHashCode = -1093198325, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 03:48:48.963266"),
            },

            new
            {
                  Id = 419, WarehouseId = 1, PalletNumber = 54, PalletHashCode = 1419325850, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:01:09.515183"),
            },

            new
            {
                  Id = 420, WarehouseId = 1, PalletNumber = 55, PalletHashCode = -918901900, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:01:27.106609"),
            },

            new
            {
                  Id = 421, WarehouseId = 1, PalletNumber = 56, PalletHashCode = -1592032269, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:02:47.222583"),
            },

            new
            {
                  Id = 422, WarehouseId = 1, PalletNumber = 57, PalletHashCode = 84102366, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:02:47.905445"),
            },

            new
            {
                  Id = 423, WarehouseId = 1, PalletNumber = 58, PalletHashCode = -1984909184, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:13.421207"),
            },

            new
            {
                  Id = 424, WarehouseId = 1, PalletNumber = 59, PalletHashCode = -1708716433, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:14.090368"),
            },

            new
            {
                  Id = 425, WarehouseId = 1, PalletNumber = 60, PalletHashCode = -1075112334, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:14.698139"),
            },

            new
            {
                  Id = 426, WarehouseId = 1, PalletNumber = 61, PalletHashCode = 1100049074, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:15.241798"),
            },

            new
            {
                  Id = 427, WarehouseId = 1, PalletNumber = 62, PalletHashCode = 493226735, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:15.947751"),
            },

            new
            {
                  Id = 428, WarehouseId = 1, PalletNumber = 63, PalletHashCode = -903709873, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:16.735090"),
            },

            new
            {
                  Id = 429, WarehouseId = 1, PalletNumber = 64, PalletHashCode = -286430102, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:17.378338"),
            },

            new
            {
                  Id = 430, WarehouseId = 1, PalletNumber = 65, PalletHashCode = 1248401289, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-09 04:13:18.028971"),
            },

            new
            {
                  Id = 431, WarehouseId = 1, PalletNumber = 66, PalletHashCode = -366353798, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:15:01.314851"),
            },

            new
            {
                  Id = 432, WarehouseId = 1, PalletNumber = 67, PalletHashCode = -1308736711, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:15:02.242389"),
            },

            new
            {
                  Id = 433, WarehouseId = 1, PalletNumber = 68, PalletHashCode = -1491205212, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:15:19.799864"),
            },

            new
            {
                  Id = 434, WarehouseId = 1, PalletNumber = 69, PalletHashCode = -117315512, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:19:11.998243"),
            },

            new
            {
                  Id = 435, WarehouseId = 1, PalletNumber = 70, PalletHashCode = -1640463658, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:19:12.630207"),
            },

            new
            {
                  Id = 436, WarehouseId = 1, PalletNumber = 71, PalletHashCode = 344486730, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:19:13.177223"),
            },

            new
            {
                  Id = 437, WarehouseId = 1, PalletNumber = 72, PalletHashCode = 1803160397, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:28:58.192776"),
            },

            new
            {
                  Id = 438, WarehouseId = 1, PalletNumber = 73, PalletHashCode = -78804368, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:28:58.204325"),
            },

            new
            {
                  Id = 439, WarehouseId = 1, PalletNumber = 74, PalletHashCode = -639457660, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:32:43.415391"),
            },

            new
            {
                  Id = 440, WarehouseId = 1, PalletNumber = 75, PalletHashCode = 1253061109, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-10 00:32:44.044964"),
            },

            new
            {
                  Id = 441, WarehouseId = 1, PalletNumber = 76, PalletHashCode = 1587695327, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:04:16.957176"),
            },

            new
            {
                  Id = 442, WarehouseId = 1, PalletNumber = 77, PalletHashCode = 1283534201, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:04:17.641479"),
            },

            new
            {
                  Id = 443, WarehouseId = 1, PalletNumber = 78, PalletHashCode = -1751487474, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:04:18.187600"),
            },

            new
            {
                  Id = 444, WarehouseId = 1, PalletNumber = 79, PalletHashCode = -2132370207, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:24:13.304100"),
            },

            new
            {
                  Id = 445, WarehouseId = 1, PalletNumber = 80, PalletHashCode = 1293335126, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:24:14.001569"),
            },

            new
            {
                  Id = 446, WarehouseId = 1, PalletNumber = 81, PalletHashCode = -2021949144, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:24:14.550253"),
            },

            new
            {
                  Id = 447, WarehouseId = 1, PalletNumber = 82, PalletHashCode = 506545946, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:31:38.511757"),
            },

            new
            {
                  Id = 448, WarehouseId = 1, PalletNumber = 83, PalletHashCode = 864506760, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:33:54.479209"),
            },

            new
            {
                  Id = 449, WarehouseId = 1, PalletNumber = 84, PalletHashCode = -2071640792, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:36:53.034049"),
            },

            new
            {
                  Id = 450, WarehouseId = 1, PalletNumber = 85, PalletHashCode = -624568661, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:36:53.777191"),
            },

            new
            {
                  Id = 451, WarehouseId = 1, PalletNumber = 86, PalletHashCode = -1770212507, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:39:57.221466"),
            },

            new
            {
                  Id = 452, WarehouseId = 1, PalletNumber = 87, PalletHashCode = -1835966192, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 04:47:45.008541"),
            },

            new
            {
                  Id = 453, WarehouseId = 1, PalletNumber = 88, PalletHashCode = 1709001057, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:20:28.415758"),
            },

            new
            {
                  Id = 454, WarehouseId = 1, PalletNumber = 89, PalletHashCode = 2145972794, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:20:29.079441"),
            },

            new
            {
                  Id = 455, WarehouseId = 1, PalletNumber = 90, PalletHashCode = 793258737, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:20:29.680054"),
            },

            new
            {
                  Id = 456, WarehouseId = 1, PalletNumber = 91, PalletHashCode = -107742489, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:20:30.286730"),
            },

            new
            {
                  Id = 457, WarehouseId = 1, PalletNumber = 92, PalletHashCode = -948700273, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:21:07.787618"),
            },

            new
            {
                  Id = 458, WarehouseId = 1, PalletNumber = 93, PalletHashCode = -2138826242, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:21:08.382287"),
            },

            new
            {
                  Id = 459, WarehouseId = 1, PalletNumber = 94, PalletHashCode = 1203984678, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:21:08.942135"),
            },

            new
            {
                  Id = 460, WarehouseId = 1, PalletNumber = 95, PalletHashCode = 2102274075, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:21:09.446224"),
            },

            new
            {
                  Id = 461, WarehouseId = 1, PalletNumber = 96, PalletHashCode = 1978421488, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:28:55.069439"),
            },

            new
            {
                  Id = 462, WarehouseId = 1, PalletNumber = 97, PalletHashCode = -2077826128, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:28:55.726030"),
            },

            new
            {
                  Id = 463, WarehouseId = 1, PalletNumber = 98, PalletHashCode = 168619599, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-13 05:28:56.345507"),
            },

            new
            {
                  Id = 464, WarehouseId = 1, PalletNumber = 99, PalletHashCode = -227632277, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-15 01:27:30.993206"),
            },

            new
            {
                  Id = 465, WarehouseId = 1, PalletNumber = 100, PalletHashCode = 195446675, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-15 01:27:31.144508"),
            },

            new
            {
                  Id = 466, WarehouseId = 1, PalletNumber = 101, PalletHashCode = -1544316081, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-15 03:13:05.014233"),
            },

            new
            {
                  Id = 467, WarehouseId = 1, PalletNumber = 102, PalletHashCode = 1207792905, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-15 03:13:05.747700"),
            },

            new
            {
                  Id = 468, WarehouseId = 1, PalletNumber = 103, PalletHashCode = 1851213644, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-16 23:27:33.839785"),
            },

            new
            {
                  Id = 469, WarehouseId = 1, PalletNumber = 104, PalletHashCode = 170631668, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-16 23:27:40.895770"),
            },

            new
            {
                  Id = 470, WarehouseId = 1, PalletNumber = 105, PalletHashCode = 1855668163, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-16 23:27:41.626065"),
            },

            new
            {
                  Id = 471, WarehouseId = 1, PalletNumber = 106, PalletHashCode = 1528483809, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-16 23:27:42.503236"),
            },

            new
            {
                  Id = 472, WarehouseId = 2, PalletNumber = 1, PalletHashCode = 1230682969, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:19:20.901049"),
            },

            new
            {
                  Id = 473, WarehouseId = 2, PalletNumber = 2, PalletHashCode = 645972440, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:25:52.939884"),
            },

            new
            {
                  Id = 474, WarehouseId = 2, PalletNumber = 3, PalletHashCode = 862020548, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:25:53.145507"),
            },

            new
            {
                  Id = 475, WarehouseId = 2, PalletNumber = 4, PalletHashCode = 275006179, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:30:55.732310"),
            },

            new
            {
                  Id = 476, WarehouseId = 2, PalletNumber = 5, PalletHashCode = 755024394, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:30:56.413919"),
            },

            new
            {
                  Id = 477, WarehouseId = 2, PalletNumber = 6, PalletHashCode = 2022406575, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:33:13.372982"),
            },

            new
            {
                  Id = 478, WarehouseId = 2, PalletNumber = 7, PalletHashCode = 1778447279, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:33:14.005230"),
            },

            new
            {
                  Id = 479, WarehouseId = 2, PalletNumber = 8, PalletHashCode = 1552646244, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:38:18.057418"),
            },

            new
            {
                  Id = 480, WarehouseId = 2, PalletNumber = 9, PalletHashCode = -1197801003, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:43:03.647331"),
            },

            new
            {
                  Id = 481, WarehouseId = 2, PalletNumber = 10, PalletHashCode = 2031492700, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:50:58.020573"),
            },

            new
            {
                  Id = 482, WarehouseId = 2, PalletNumber = 11, PalletHashCode = -1460276000, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:58:55.101828"),
            },

            new
            {
                  Id = 483, WarehouseId = 2, PalletNumber = 12, PalletHashCode = -675629490, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:58:55.942657"),
            },

            new
            {
                  Id = 484, WarehouseId = 2, PalletNumber = 13, PalletHashCode = -761185692, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 08:59:03.783802"),
            },

            new
            {
                  Id = 485, WarehouseId = 2, PalletNumber = 14, PalletHashCode = 1262109008, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 09:04:05.911848"),
            },

            new
            {
                  Id = 486, WarehouseId = 2, PalletNumber = 15, PalletHashCode = -63643778, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-29 09:04:08.050055"),
            },

            new
            {
                  Id = 487, WarehouseId = 2, PalletNumber = 16, PalletHashCode = -553881046, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-31 02:42:03.626798"),
            },

            new
            {
                  Id = 488, WarehouseId = 2, PalletNumber = 17, PalletHashCode = 686271052, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-31 02:42:04.030074"),
            },

            new
            {
                  Id = 489, WarehouseId = 2, PalletNumber = 18, PalletHashCode = -176856354, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-31 02:42:04.604144"),
            },

            new
            {
                  Id = 490, WarehouseId = 2, PalletNumber = 19, PalletHashCode = 532330216, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-05-31 03:04:20.120830"),
            },

            new
            {
                  Id = 491, WarehouseId = 2, PalletNumber = 20, PalletHashCode = -1066189881, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:16:45.746519"),
            },

            new
            {
                  Id = 492, WarehouseId = 2, PalletNumber = 21, PalletHashCode = 1558556560, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:16:46.446732"),
            },

            new
            {
                  Id = 493, WarehouseId = 2, PalletNumber = 22, PalletHashCode = 1141022357, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:16:47.262847"),
            },

            new
            {
                  Id = 494, WarehouseId = 2, PalletNumber = 23, PalletHashCode = 1904293152, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:16:47.844739"),
            },

            new
            {
                  Id = 495, WarehouseId = 2, PalletNumber = 24, PalletHashCode = 1213235935, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:16:48.413995"),
            },

            new
            {
                  Id = 496, WarehouseId = 2, PalletNumber = 25, PalletHashCode = 1615510191, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 02:30:18.970786"),
            },

            new
            {
                  Id = 497, WarehouseId = 2, PalletNumber = 26, PalletHashCode = -321333027, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:29:11.182204"),
            },

            new
            {
                  Id = 498, WarehouseId = 2, PalletNumber = 27, PalletHashCode = 414654264, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:29:11.954636"),
            },

            new
            {
                  Id = 499, WarehouseId = 2, PalletNumber = 28, PalletHashCode = -1656828590, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:29:12.006728"),
            },

            new
            {
                  Id = 500, WarehouseId = 2, PalletNumber = 29, PalletHashCode = 512975954, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:29:12.515238"),
            },

            new
            {
                  Id = 501, WarehouseId = 2, PalletNumber = 30, PalletHashCode = -675204134, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:40:46.237047"),
            },

            new
            {
                  Id = 502, WarehouseId = 2, PalletNumber = 31, PalletHashCode = 690737558, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:45:24.699658"),
            },

            new
            {
                  Id = 503, WarehouseId = 2, PalletNumber = 32, PalletHashCode = -1765415085, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:45:25.372272"),
            },

            new
            {
                  Id = 504, WarehouseId = 2, PalletNumber = 33, PalletHashCode = -1564917424, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:45:25.826771"),
            },

            new
            {
                  Id = 505, WarehouseId = 2, PalletNumber = 34, PalletHashCode = -1669243508, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:45:26.241538"),
            },

            new
            {
                  Id = 506, WarehouseId = 2, PalletNumber = 35, PalletHashCode = 1631107571, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:45:35.219700"),
            },

            new
            {
                  Id = 507, WarehouseId = 2, PalletNumber = 36, PalletHashCode = -1304223134, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 07:54:10.299650"),
            },

            new
            {
                  Id = 508, WarehouseId = 2, PalletNumber = 37, PalletHashCode = 769544500, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:01.408386"),
            },

            new
            {
                  Id = 509, WarehouseId = 2, PalletNumber = 38, PalletHashCode = -578092697, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:01.571977"),
            },

            new
            {
                  Id = 510, WarehouseId = 2, PalletNumber = 39, PalletHashCode = 1122287383, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:01.717185"),
            },

            new
            {
                  Id = 511, WarehouseId = 2, PalletNumber = 40, PalletHashCode = -599974417, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:01.863949"),
            },

            new
            {
                  Id = 512, WarehouseId = 2, PalletNumber = 41, PalletHashCode = 326031833, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:02.009002"),
            },

            new
            {
                  Id = 513, WarehouseId = 2, PalletNumber = 42, PalletHashCode = -1970342949, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:02:02.118149"),
            },

            new
            {
                  Id = 514, WarehouseId = 2, PalletNumber = 43, PalletHashCode = -1757987509, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.319261"),
            },

            new
            {
                  Id = 515, WarehouseId = 2, PalletNumber = 43, PalletHashCode = 32544192, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.321782"),
            },

            new
            {
                  Id = 516, WarehouseId = 2, PalletNumber = 44, PalletHashCode = 1307011447, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.332549"),
            },

            new
            {
                  Id = 517, WarehouseId = 2, PalletNumber = 45, PalletHashCode = 361983424, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.451900"),
            },

            new
            {
                  Id = 518, WarehouseId = 2, PalletNumber = 46, PalletHashCode = 1465950619, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.614246"),
            },

            new
            {
                  Id = 519, WarehouseId = 2, PalletNumber = 47, PalletHashCode = 418578155, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 08:16:40.779572"),
            },

            new
            {
                  Id = 520, WarehouseId = 2, PalletNumber = 48, PalletHashCode = 1053663059, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:14:58.352713"),
            },

            new
            {
                  Id = 521, WarehouseId = 2, PalletNumber = 49, PalletHashCode = -1285554869, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:14:58.959469"),
            },

            new
            {
                  Id = 522, WarehouseId = 2, PalletNumber = 50, PalletHashCode = -434008255, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:14:59.502382"),
            },

            new
            {
                  Id = 523, WarehouseId = 2, PalletNumber = 51, PalletHashCode = -136993850, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:15:00.121898"),
            },

            new
            {
                  Id = 524, WarehouseId = 2, PalletNumber = 52, PalletHashCode = 1593846227, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:15:00.783645"),
            },

            new
            {
                  Id = 525, WarehouseId = 2, PalletNumber = 53, PalletHashCode = -1061727491, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-02 09:15:01.293583"),
            },

            new
            {
                  Id = 526, WarehouseId = 2, PalletNumber = 54, PalletHashCode = 326525530, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:05:50.549803"),
            },

            new
            {
                  Id = 527, WarehouseId = 2, PalletNumber = 55, PalletHashCode = -882891001, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:05:50.787851"),
            },

            new
            {
                  Id = 528, WarehouseId = 2, PalletNumber = 56, PalletHashCode = -50908549, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:05:51.460490"),
            },

            new
            {
                  Id = 529, WarehouseId = 2, PalletNumber = 57, PalletHashCode = -928289621, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:05:51.991867"),
            },

            new
            {
                  Id = 530, WarehouseId = 2, PalletNumber = 58, PalletHashCode = 1777516658, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:36:58.820444"),
            },

            new
            {
                  Id = 531, WarehouseId = 2, PalletNumber = 59, PalletHashCode = 1194968779, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:36:59.231377"),
            },

            new
            {
                  Id = 532, WarehouseId = 2, PalletNumber = 60, PalletHashCode = -988036519, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:36:59.667494"),
            },

            new
            {
                  Id = 533, WarehouseId = 2, PalletNumber = 61, PalletHashCode = -174670964, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:37:00.196775"),
            },

            new
            {
                  Id = 534, WarehouseId = 2, PalletNumber = 62, PalletHashCode = -1315868896, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:45:42.240987"),
            },

            new
            {
                  Id = 535, WarehouseId = 2, PalletNumber = 63, PalletHashCode = 874889837, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:45:42.645490"),
            },

            new
            {
                  Id = 536, WarehouseId = 2, PalletNumber = 64, PalletHashCode = 1746866050, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:45:43.256419"),
            },

            new
            {
                  Id = 537, WarehouseId = 2, PalletNumber = 65, PalletHashCode = 213426622, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:53:58.461131"),
            },

            new
            {
                  Id = 538, WarehouseId = 2, PalletNumber = 66, PalletHashCode = 47068616, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:53:59.286282"),
            },

            new
            {
                  Id = 539, WarehouseId = 2, PalletNumber = 67, PalletHashCode = 1119574873, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:54:00.184654"),
            },

            new
            {
                  Id = 540, WarehouseId = 2, PalletNumber = 68, PalletHashCode = -2103654151, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:54:01.048867"),
            },

            new
            {
                  Id = 541, WarehouseId = 2, PalletNumber = 69, PalletHashCode = -1894574697, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 07:55:23.938796"),
            },

            new
            {
                  Id = 542, WarehouseId = 2, PalletNumber = 70, PalletHashCode = 993286031, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 08:29:22.430583"),
            },

            new
            {
                  Id = 543, WarehouseId = 2, PalletNumber = 71, PalletHashCode = 1581696992, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 08:29:22.539471"),
            },

            new
            {
                  Id = 544, WarehouseId = 2, PalletNumber = 72, PalletHashCode = 266727393, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 08:29:22.671154"),
            },

            new
            {
                  Id = 545, WarehouseId = 2, PalletNumber = 73, PalletHashCode = 296251884, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 08:29:22.828758"),
            },

            new
            {
                  Id = 546, WarehouseId = 2, PalletNumber = 74, PalletHashCode = 621624807, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-04 08:29:22.915804"),
            },

            new
            {
                  Id = 547, WarehouseId = 2, PalletNumber = 75, PalletHashCode = -434295120, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 02:41:23.042399"),
            },

            new
            {
                  Id = 548, WarehouseId = 2, PalletNumber = 76, PalletHashCode = 516645270, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 02:52:32.645244"),
            },

            new
            {
                  Id = 549, WarehouseId = 2, PalletNumber = 77, PalletHashCode = 294699678, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 05:24:27.023052"),
            },

            new
            {
                  Id = 550, WarehouseId = 2, PalletNumber = 78, PalletHashCode = 422744706, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 05:30:41.258379"),
            },

            new
            {
                  Id = 551, WarehouseId = 2, PalletNumber = 79, PalletHashCode = -454382323, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 07:13:04.480849"),
            },

            new
            {
                  Id = 552, WarehouseId = 2, PalletNumber = 80, PalletHashCode = 1796171563, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 07:13:05.761727"),
            },

            new
            {
                  Id = 553, WarehouseId = 2, PalletNumber = 81, PalletHashCode = -135340982, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 07:42:32.863576"),
            },

            new
            {
                  Id = 554, WarehouseId = 2, PalletNumber = 82, PalletHashCode = 228727657, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 08:13:54.637800"),
            },

            new
            {
                  Id = 555, WarehouseId = 2, PalletNumber = 83, PalletHashCode = 73233165, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-11 08:37:08.330936"),
            },
            new
            {
                  Id = 556, WarehouseId = 1, PalletNumber = 107, PalletHashCode = 1621056683, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-18 02:04:00.586970"),
            },

            new
            {
                  Id = 557, WarehouseId = 1, PalletNumber = 108, PalletHashCode = -517273955, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-18 02:04:01.142524"),
            },

            new
            {
                  Id = 558, WarehouseId = 1, PalletNumber = 109, PalletHashCode = -276464502, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-18 02:04:01.614751"),
            },

            new
            {
                  Id = 559, WarehouseId = 1, PalletNumber = 110, PalletHashCode = 414054040, PalletDimension = "",
                  CapacityInKG = 0.0m, CapacityInCBM = 0.0m,
                  DateAdded = Convert.ToDateTime("2025-06-18 02:04:02.037933"),
            }
      );
      
      modelBuilder.Entity<Receiving>().HasData(
            new
            {
                  Id = 1, Series = "SLCWH-00001-25", WarehouseId = 1, TransportCompany = "REGENT FOOD CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-10 00:00:00.000000"), Reference = "BS23580", PlateNumber = "NAQ9905", DriverName = "NORBERTO TAMON",
                  DateTime = Convert.ToDateTime("2025-01-10 08:33:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CORTE",
                  TimeStart = Convert.ToDateTime("2025-01-10 08:33:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-10 10:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 01:48:42.000000"),
            },

            new
            {
                  Id = 2, Series = "SLCWH-00002-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009660", PlateNumber = "NAQ3433", DriverName = "GERMAN ALILING",
                  DateTime = Convert.ToDateTime("2025-01-15 12:30:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 12:30:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 12:57:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:48:32.000000"),
            },

            new
            {
                  Id = 3, Series = "SLCWH-00003-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING COPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009350", PlateNumber = "NAM4312", DriverName = "JOEY ANASTACIO",
                  DateTime = Convert.ToDateTime("2025-01-15 13:00:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 13:00:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 13:15:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 01:58:01.000000"),
            },

            new
            {
                  Id = 4, Series = "SLCWH-00004-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009681", PlateNumber = "NHF7527", DriverName = "JANWARREN REYES",
                  DateTime = Convert.ToDateTime("2025-01-15 13:17:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 13:17:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 13:40:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:00:00.000000"),
            },

            new
            {
                  Id = 5, Series = "SLCWH-00005-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING COPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009680", PlateNumber = "CAJ8292", DriverName = "RANDOLPH MAGDAMIT",
                  DateTime = Convert.ToDateTime("2025-01-15 13:43:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 13:43:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 14:04:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:01:27.000000"),
            },

            new
            {
                  Id = 6, Series = "SLCWH-00006-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009707", PlateNumber = "XTB145", DriverName = "JANVIE CABALE",
                  DateTime = Convert.ToDateTime("2025-01-15 14:09:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 14:09:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 14:32:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:18:28.000000"),
            },

            new
            {
                  Id = 7, Series = "SLCWH-00007-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009711", PlateNumber = "NIO8373", DriverName = "JAYNARD CLAVO",
                  DateTime = Convert.ToDateTime("2025-01-15 14:35:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 14:35:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 14:45:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:20:34.000000"),
            },

            new
            {
                  Id = 8, Series = "SLCWH-00008-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009713", PlateNumber = "NBS2417", DriverName = "ALLAN BARREDO",
                  DateTime = Convert.ToDateTime("2025-01-15 14:52:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 14:52:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 15:05:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:24:44.000000"),
            },

            new
            {
                  Id = 9, Series = "SLCWH-00009-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-15 00:00:00.000000"), Reference = "SI8100009712", PlateNumber = "NBR9810", DriverName = "MARK EDISON REGENCIA",
                  DateTime = Convert.ToDateTime("2025-01-15 15:11:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-15 15:11:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-15 15:24:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:27:11.000000"),
            },

            new
            {
                  Id = 10, Series = "SLCWH-00010-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-16 00:00:00.000000"), Reference = "SI8100010505", PlateNumber = "XTK237", DriverName = "JEYVIN HELIS",
                  DateTime = Convert.ToDateTime("2025-01-16 11:45:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-16 11:45:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-16 12:06:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:29:22.000000"),
            },

            new
            {
                  Id = 11, Series = "SLCWH-00011-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-16 00:00:00.000000"), Reference = "SI8100010504", PlateNumber = "NAO9918", DriverName = "JOHANSON OLIVEROS",
                  DateTime = Convert.ToDateTime("2025-01-16 12:08:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-16 12:08:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-16 12:26:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:35:41.000000"),
            },

            new
            {
                  Id = 12, Series = "SLCWH-00012-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-16 00:00:00.000000"), Reference = "SI8100010518", PlateNumber = "CAJ8292", DriverName = "RANDOLPH MAGDAMIT",
                  DateTime = Convert.ToDateTime("2025-01-16 13:45:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-16 01:45:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-16 14:31:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:38:14.000000"),
            },

            new
            {
                  Id = 13, Series = "SLCWH-00013-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-17 00:00:00.000000"), Reference = "SI8100011269", PlateNumber = "NAM4312", DriverName = "JOEY ANASTACIO",
                  DateTime = Convert.ToDateTime("2025-01-17 09:02:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-17 09:02:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-17 10:04:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:40:45.000000"),
            },

            new
            {
                  Id = 14, Series = "SLCWH-00014-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-17 00:00:00.000000"), Reference = "SI8100011267", PlateNumber = "NAM4312", DriverName = "JOEY ANASTACIO",
                  DateTime = Convert.ToDateTime("2025-01-17 09:02:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-17 09:02:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-07 10:04:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-22 02:44:46.000000"),
            },

            new
            {
                  Id = 18, Series = "SLCWH-00015-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-20 00:00:00.000000"), Reference = "INV 103001428147", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-01-20 10:24:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-20 10:24:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-20 11:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-25 02:30:20.000000"),
            },

            new
            {
                  Id = 19, Series = "SLCWH-00016-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-20 00:00:00.000000"), Reference = "INV 103001428148", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-01-20 10:24:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-20 10:24:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-20 11:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-25 02:33:39.000000"),
            },

            new
            {
                  Id = 20, Series = "SLCWH-00017-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-01-20 00:00:00.000000"), Reference = "INV 103001428146", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-01-20 10:24:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-01-20 10:24:00.000000"), TimeEnd = Convert.ToDateTime("2025-01-20 11:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-25 02:36:43.000000"),
            },

            new
            {
                  Id = 21, Series = "SLCWH-00018-25", WarehouseId = 1, TransportCompany = "SKYBEST LOGISTICS CORPORATION", Shipper = "FLUTAI COMPANY LIMITED", Consignee = "BESTCHILL INC",
                  DateReceived =  Convert.ToDateTime("2022-11-26 00:00:00.000000"), Reference = "INV AA-1111001", PlateNumber = "ABC1234", DriverName = "ASDAD",
                  DateTime = Convert.ToDateTime("2024-11-26 09:00:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2022-11-26 09:00:00.000000"), TimeEnd = Convert.ToDateTime("2022-11-26 11:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-01-25 03:25:23.000000"),
            },

            new
            {
                  Id = 22, Series = "SLCWH-00019-25", WarehouseId = 1, TransportCompany = "REGENT FOODS CORP / JWDC TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-02-25 01:10:32.000000"), Reference = "1106083", PlateNumber = "NBE7478", DriverName = "Samuel Ramos",
                  DateTime = Convert.ToDateTime("2025-02-25 08:34:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-02-25 08:34:00.000000"), TimeEnd = Convert.ToDateTime("2025-02-25 09:58:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-07 10:00:34.000000"),
            },

            new
            {
                  Id = 23, Series = "SLCWH-00020-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047950", PlateNumber = "CBB4965", DriverName = "RINATO LOPEZ",
                  DateTime = Convert.ToDateTime("2025-03-04 08:35:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 08:35:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 09:17:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:02:50.000000"),
            },

            new
            {
                  Id = 24, Series = "SLCWH-00021-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047812", PlateNumber = "NIO 8373", DriverName = "Jaynard Clavo",
                  DateTime = Convert.ToDateTime("2025-03-04 09:24:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 09:24:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 09:38:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:09:07.000000"),
            },

            new
            {
                  Id = 25, Series = "SLCWH-00022-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047630", PlateNumber = "NAO 9915", DriverName = "JOHANSON OLIVEROS",
                  DateTime = Convert.ToDateTime("2025-03-04 10:15:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 10:15:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 10:35:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:11:42.000000"),
            },

            new
            {
                  Id = 26, Series = "SLCWH-00023-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047625", PlateNumber = "NBT 8366", DriverName = "GERMAN ALILING",
                  DateTime = Convert.ToDateTime("2025-03-04 10:38:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 10:38:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 11:09:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:17:28.000000"),
            },

            new
            {
                  Id = 27, Series = "SLCWH-00024-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-05 01:17:42.000000"), Reference = "8100047587", PlateNumber = "NBT 8366", DriverName = "GERMAN ALILING",
                  DateTime = Convert.ToDateTime("2025-03-04 10:38:00.000000"), ClientRepresentative = "", CheckerName = "",
                  TimeStart = Convert.ToDateTime("2025-03-04 10:38:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 11:09:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:22:00.000000"),
            },

            new
            {
                  Id = 28, Series = "SLCWH-00025-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047808", PlateNumber = "NAQ 3433", DriverName = "MICHAEL GARLANDO",
                  DateTime = Convert.ToDateTime("2025-03-04 11:11:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 11:11:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 11:28:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:26:18.000000"),
            },

            new
            {
                  Id = 29, Series = "SLCWH-00026-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-04 00:00:00.000000"), Reference = "8100047804", PlateNumber = "NBR 9963", DriverName = "ELWEN ACOS",
                  DateTime = Convert.ToDateTime("2025-03-04 11:30:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-04 11:30:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-04 11:43:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 01:28:32.000000"),
            },

            new
            {
                  Id = 30, Series = "SLCWH-00027-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-05 02:21:11.000000"), Reference = "8100048625", PlateNumber = "RHE 512", DriverName = "JOHANSON OLIVEROS",
                  DateTime = Convert.ToDateTime("2025-03-05 08:31:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-05 08:31:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-05 08:52:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 02:28:09.000000"),
            },

            new
            {
                  Id = 31, Series = "SLCWH-00028-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-05 02:30:10.000000"), Reference = "8100048620", PlateNumber = "NAQ 3433", DriverName = "J. DELA CERNA",
                  DateTime = Convert.ToDateTime("2025-03-05 09:30:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-05 09:30:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-05 09:59:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 02:33:28.000000"),
            },

            new
            {
                  Id = 32, Series = "SLCWH-00029-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-05 03:30:54.000000"), Reference = "8100048619", PlateNumber = "NBT 8366", DriverName = "GERMAN ALILING",
                  DateTime = Convert.ToDateTime("2025-03-05 10:59:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-05 10:59:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-05 11:36:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 03:37:27.000000"),
            },

            new
            {
                  Id = 33, Series = "SLCWH-00030-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-03-05 05:59:58.000000"), Reference = "8100048629", PlateNumber = "XTB145", DriverName = "ERNESTO JAMERO",
                  DateTime = Convert.ToDateTime("2025-03-05 01:35:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-03-05 01:35:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-05 01:58:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-05 06:32:30.000000"),
            },

            new
            {
                  Id = 34, Series = "SLCWH-00031-25", WarehouseId = 1, TransportCompany = "SKYBEST LOGISTICS CORPORATION", Shipper = "DONGGUAN TONGDA STORAGE SERVE CO., LTD.", Consignee = "BESTCHILL INC",
                  DateReceived =  Convert.ToDateTime("2025-03-07 00:00:00.000000"), Reference = "INV: 20221118", PlateNumber = "ABC1234", DriverName = "JERSON",
                  DateTime = Convert.ToDateTime("2025-03-07 13:10:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-03-07 13:10:00.000000"), TimeEnd = Convert.ToDateTime("2025-03-07 13:35:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-03-13 02:26:56.000000"),
            },

            new
            {
                  Id = 35, Series = "SLCWH-00032-25", WarehouseId = 1, TransportCompany = "Zesto Corporation", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-04-08 01:38:26.000000"), Reference = "ZMC-0010", PlateNumber = "NKF2611", DriverName = "JANCARL DEL ROSARIO",
                  DateTime = Convert.ToDateTime("2025-08-04 09:00:00.000000"), ClientRepresentative = "", CheckerName = "JAN MICHAEL LARDIZABAL",
                  TimeStart = Convert.ToDateTime("2025-08-04 09:00:00.000000"), TimeEnd = Convert.ToDateTime("2025-08-04 09:40:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-04-08 01:45:52.000000"),
            },

            new
            {
                  Id = 36, Series = "SLCWH-00033-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-09 02:06:05.000000"), Reference = "SI8100093852", PlateNumber = "NBY 4315", DriverName = "JOHN CUTAMORA",
                  DateTime = Convert.ToDateTime("2025-05-09 08:34:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-05-09 08:34:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-09 09:42:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-09 02:10:52.000000"),
            },

            new
            {
                  Id = 37, Series = "SLCWH-00034-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-09 02:11:14.000000"), Reference = "SI8100093853", PlateNumber = "NBY 4315", DriverName = "JOHN CUTAMORA",
                  DateTime = Convert.ToDateTime("2025-05-09 08:34:00.000000"), ClientRepresentative = "", CheckerName = "VAN VERGEL CONTE",
                  TimeStart = Convert.ToDateTime("2025-05-09 08:34:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-09 09:42:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-09 02:14:01.000000"),
            },

            new
            {
                  Id = 38, Series = "SLCWH-00035-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-09 02:14:10.000000"), Reference = "SI8100093854", PlateNumber = "ABK 6586", DriverName = "JONVIE CABALE",
                  DateTime = Convert.ToDateTime("2025-05-09 09:44:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-09 09:44:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-09 10:13:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-09 02:19:18.000000"),
            },

            new
            {
                  Id = 39, Series = "SLCWH-00036-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-09 03:27:08.000000"), Reference = "SI8100093962", PlateNumber = "NBX 7265", DriverName = "ALEX QUERIZA",
                  DateTime = Convert.ToDateTime("2025-05-09 10:34:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-09 10:34:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-09 11:51:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-09 03:58:40.000000"),
            },

            new
            {
                  Id = 40, Series = "SLCWH-00037-25", WarehouseId = 1, TransportCompany = "LIWAYWAY MARKETING CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-09 04:12:22.000000"), Reference = "SI8100094566", PlateNumber = "CCO 5221", DriverName = "JEFERSON URCIA",
                  DateTime = Convert.ToDateTime("2025-05-09 11:55:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-09 11:55:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-09 00:08:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-09 04:20:11.000000"),
            },

            new
            {
                  Id = 41, Series = "SLCWH-00038-25", WarehouseId = 1, TransportCompany = "MAGIS DISTRIBUTION INC", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-10 00:19:10.000000"), Reference = "26887", PlateNumber = "GAK 2456", DriverName = "ANGELO PADRE",
                  DateTime = Convert.ToDateTime("2025-05-10 07:31:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-10 07:31:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-10 07:46:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-10 00:22:30.000000"),
            },

            new
            {
                  Id = 42, Series = "SLCWH-00039-25", WarehouseId = 1, TransportCompany = "JARCFMCG DISTRIBUTIONG CORP.", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-10 00:32:14.000000"), Reference = "10068437", PlateNumber = "UIX 617", DriverName = "ALEX ENCISO",
                  DateTime = Convert.ToDateTime("2025-05-10 07:49:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-10 07:49:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-10 07:52:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-10 00:34:35.000000"),
            },

            new
            {
                  Id = 43, Series = "SLCWH-00040-25", WarehouseId = 1, TransportCompany = "REGENT FOOD CORPORATION / JWDS", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 02:21:25.000000"), Reference = "BS 239266", PlateNumber = "NEG 4134", DriverName = "JERIC ZETA",
                  DateTime = Convert.ToDateTime("2025-05-13 08:43:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 08:43:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 10:18:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 02:25:33.000000"),
            },

            new
            {
                  Id = 44, Series = "SLCWH-00041-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:23:30.000000"), Reference = "INV: 103001724905", PlateNumber = "CAH 3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:30:49.000000"),
            },

            new
            {
                  Id = 45, Series = "SLCWH-00042-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:31:07.000000"), Reference = "INV: 103001724906", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:44:25.000000"),
            },

            new
            {
                  Id = 46, Series = "SLCWH-00043-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:33:20.000000"), Reference = "INV: 103001724908", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:35:11.000000"),
            },

            new
            {
                  Id = 47, Series = "SLCWH-00044-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:35:16.000000"), Reference = "INV: 103001724910", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:39:12.000000"),
            },

            new
            {
                  Id = 48, Series = "SLCWH-00045-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:39:22.000000"), Reference = "INV: 103001724911", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:46:40.000000"),
            },

            new
            {
                  Id = 49, Series = "SLCWH-00046-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 04:47:28.000000"), Reference = "INV: 103001724912", PlateNumber = "CAH3355", DriverName = "FELIPE POBLEO",
                  DateTime = Convert.ToDateTime("2025-05-13 10:42:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 10:42:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 11:48:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 04:48:42.000000"),
            },

            new
            {
                  Id = 50, Series = "SLCWH-00047-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 05:20:48.000000"), Reference = "INV: 103001724907", PlateNumber = "CAL 3472", DriverName = "ELIAZAR UMOQUIT",
                  DateTime = Convert.ToDateTime("2025-05-13 13:05:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 13:05:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 13:23:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 05:28:06.000000"),
            },

            new
            {
                  Id = 51, Series = "SLCWH-00048-25", WarehouseId = 1, TransportCompany = "SUYSING COMMERCIAL CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-13 05:28:13.000000"), Reference = "INV: 103001724909", PlateNumber = "CAL 3472", DriverName = "ELIAZAR UMOQUIT",
                  DateTime = Convert.ToDateTime("2025-05-13 13:05:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-13 13:05:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-13 13:23:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-13 05:31:57.000000"),
            },

            new
            {
                  Id = 52, Series = "SLCWH-00049-25", WarehouseId = 1, TransportCompany = "PRIFOOD CORPORATION", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-15 01:27:11.000000"), Reference = "264051", PlateNumber = "NAN2206", DriverName = "RISER SORIANO",
                  DateTime = Convert.ToDateTime("2025-05-15 09:11:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-15 09:11:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-15 09:24:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-15 01:29:00.000000"),
            },

            new
            {
                  Id = 53, Series = "SLCWH-00050-25", WarehouseId = 1, TransportCompany = "WL FOODS (LALAMOVE)", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-15 03:12:22.000000"), Reference = "0", PlateNumber = "NKF3224", DriverName = "EDWIN PADEROS",
                  DateTime = Convert.ToDateTime("2025-05-15 10:58:00.000000"), ClientRepresentative = "", CheckerName = "TIMOTHY AMBROSE MANALAYSAY",
                  TimeStart = Convert.ToDateTime("2025-05-15 10:58:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-15 11:11:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-15 03:16:17.000000"),
            },

            new
            {
                  Id = 54, Series = "SLCWH-00051-25", WarehouseId = 1, TransportCompany = "WL FOODS PRODUCTS", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-16 23:27:22.000000"), Reference = "DR01319916", PlateNumber = "CCB6518", DriverName = "ROBERT DOMINGO JR",
                  DateTime = Convert.ToDateTime("2025-05-17 07:20:00.000000"), ClientRepresentative = "", CheckerName = "JAN MICHAEL LARDIZABAL",
                  TimeStart = Convert.ToDateTime("2025-05-17 07:20:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-17 07:30:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-16 23:35:34.000000"),
            },

            new
            {
                  Id = 55, Series = "SLCWH-00052-25", WarehouseId = 2, TransportCompany = "SUY SING / VILLALIMA", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-28 00:00:00.000000"), Reference = "104001000000", PlateNumber = "CAZ 1482", DriverName = "LYMART BONGAHOY",
                  DateTime = Convert.ToDateTime("2025-05-28 15:32:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-28 15:32:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-28 15:39:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 09:23:25.000000"),
            },

            new
            {
                  Id = 56, Series = "SLCWH-00053-25", WarehouseId = 2, TransportCompany = "ZESTO CORPORATION / 2K2J-2", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-29 08:32:36.000000"), Reference = "178615", PlateNumber = "CAB 5802", DriverName = "MARK ANTHONY PADILLA",
                  DateTime = Convert.ToDateTime("2025-05-29 07:50:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-29 07:50:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-29 08:09:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 09:30:42.000000"),
            },

            new
            {
                  Id = 57, Series = "SLCWH-00054-25", WarehouseId = 2, TransportCompany = "LIANA'S DAILY MART", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-29 08:42:53.000000"), Reference = "14021", PlateNumber = "DBM 4751", DriverName = "LESTER SANCHEZ",
                  DateTime = Convert.ToDateTime("2025-05-29 12:15:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-29 12:15:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-29 12:21:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 08:47:43.000000"),
            },

            new
            {
                  Id = 58, Series = "SLCWH-00055-25", WarehouseId = 2, TransportCompany = "AZUCAR DISTRIBUTION", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-29 08:49:16.000000"), Reference = "52422", PlateNumber = "NHC 5016", DriverName = "LARRY BULAGNER",
                  DateTime = Convert.ToDateTime("2025-05-29 14:49:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-29 14:49:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-29 14:55:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 08:52:53.000000"),
            },

            new
            {
                  Id = 59, Series = "SLCWH-00056-25", WarehouseId = 2, TransportCompany = "BESTMART", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-29 08:58:09.000000"), Reference = "314", PlateNumber = "NKP 4704", DriverName = "RYAN ARTUGUE",
                  DateTime = Convert.ToDateTime("2025-05-28 14:37:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-28 14:37:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-28 14:44:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 09:03:20.000000"),
            },

            new
            {
                  Id = 60, Series = "SLCWH-00057-25", WarehouseId = 2, TransportCompany = "BESTMART", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-29 09:03:50.000000"), Reference = "316", PlateNumber = "NKH 1349", DriverName = "DOMINIC BALUYOT",
                  DateTime = Convert.ToDateTime("2025-05-28 15:32:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-28 15:32:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-28 15:39:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-05-29 09:05:32.000000"),
            },

            new
            {
                  Id = 62, Series = "SLCWH-00058-25", WarehouseId = 2, TransportCompany = "SUY SING", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-28 00:00:00.000000"), Reference = "104001000000", PlateNumber = "NCK 9038", DriverName = "MAG MINOZA",
                  DateTime = Convert.ToDateTime("2025-05-28 09:01:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-28 09:01:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-28 09:41:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-02 07:44:15.000000"),
            },

            new
            {
                  Id = 63, Series = "SLCWH-00059-25", WarehouseId = 2, TransportCompany = "SUYSING", Shipper = "RCV", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-05-28 00:00:00.000000"), Reference = "104001000000", PlateNumber = "CBS 2980", DriverName = "ALEX BORIGAS",
                  DateTime = Convert.ToDateTime("2025-05-28 08:15:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-05-28 08:15:00.000000"), TimeEnd = Convert.ToDateTime("2025-05-28 08:59:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-02 09:33:53.000000"),
            },

            new
            {
                  Id = 64, Series = "SLCWH-00060-25", WarehouseId = 2, TransportCompany = "SUYSING / TSM TRUCKING", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-04 07:36:32.000000"), Reference = "104001000000", PlateNumber = "PQD 200", DriverName = "JOEL EDEM",
                  DateTime = Convert.ToDateTime("2025-06-04 08:50:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-04 08:50:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-04 09:40:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-04 07:43:40.000000"),
            },

            new
            {
                  Id = 65, Series = "SLCWH-00061-25", WarehouseId = 2, TransportCompany = "PSWRI", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-04 07:44:07.000000"), Reference = "11505", PlateNumber = "GAA 5050", DriverName = "ARTHUR ROJAS",
                  DateTime = Convert.ToDateTime("2025-06-04 09:45:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-04 09:45:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-04 10:43:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-04 07:52:28.000000"),
            },

            new
            {
                  Id = 66, Series = "SLCWH-00062-25", WarehouseId = 2, TransportCompany = "SUYSING / TSM TRUCKING", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-04 08:28:36.000000"), Reference = "104001000000", PlateNumber = "NAF 7231", DriverName = "RUPERTO CHERRY",
                  DateTime = Convert.ToDateTime("2025-06-04 10:47:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-04 10:47:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-04 11:47:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-04 08:43:33.000000"),
            },

            new
            {
                  Id = 67, Series = "SLCWH-00063-25", WarehouseId = 2, TransportCompany = "EJJC-3 TRUCKING", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-11 02:39:01.000000"), Reference = "2024-0080", PlateNumber = "NHL 5003", DriverName = "VICSON CUDAL",
                  DateTime = Convert.ToDateTime("2025-06-05 08:30:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-05 08:30:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-05 08:50:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 02:44:27.000000"),
            },

            new
            {
                  Id = 68, Series = "SLCWH-00064-25", WarehouseId = 2, TransportCompany = "BILLIES", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-05 00:00:00.000000"), Reference = "73251", PlateNumber = "XPL 733", DriverName = "MARK VALENUEVA",
                  DateTime = Convert.ToDateTime("2025-06-05 09:40:00.000000"), ClientRepresentative = "", CheckerName = "",
                  TimeStart = Convert.ToDateTime("2025-06-05 09:40:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-05 09:54:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 03:39:18.000000"),
            },

            new
            {
                  Id = 69, Series = "SLCWH-00065-25", WarehouseId = 2, TransportCompany = "BILLIES", Shipper = "SUNRISE UNLIMITED TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-05 00:00:00.000000"), Reference = "73251", PlateNumber = "XPL 733", DriverName = "MARK VALENUEVA",
                  DateTime = Convert.ToDateTime("2025-06-05 09:40:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-05 09:40:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-05 09:54:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 03:39:32.000000"),
            },

            new
            {
                  Id = 70, Series = "SLCWH-00066-25", WarehouseId = 2, TransportCompany = "MANIMALIX", Shipper = "SUNRISE TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-05 00:00:00.000000"), Reference = "239091", PlateNumber = "NEV 4353", DriverName = "JIMMY BOB VISTAL",
                  DateTime = Convert.ToDateTime("2025-06-05 13:02:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-05 13:02:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-05 13:50:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 05:44:17.000000"),
            },

            new
            {
                  Id = 71, Series = "SLCWH-00067-25", WarehouseId = 2, TransportCompany = "OGB FOOD", Shipper = "SUNRISE TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-09 00:00:00.000000"), Reference = "1427", PlateNumber = "NAB 080", DriverName = "JOHN CABILLO",
                  DateTime = Convert.ToDateTime("2025-06-09 10:48:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-09 10:48:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-09 11:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 07:32:10.000000"),
            },

            new
            {
                  Id = 72, Series = "SLCWH-00068-25", WarehouseId = 2, TransportCompany = "MANIMALIX", Shipper = "SUNRISE TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-09 00:00:00.000000"), Reference = "239091", PlateNumber = "NEV 4353", DriverName = "JIMMY BOB VISTAL",
                  DateTime = Convert.ToDateTime("2025-06-09 08:30:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-09 08:30:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-09 08:35:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 07:46:28.000000"),
            },

            new
            {
                  Id = 73, Series = "SLCWH-00069-25", WarehouseId = 2, TransportCompany = "PIXCEL", Shipper = "SUNRISE TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-07 00:00:00.000000"), Reference = "55384", PlateNumber = "RES 126", DriverName = "FLORO NOFIES",
                  DateTime = Convert.ToDateTime("2025-06-07 09:00:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-07 09:00:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-07 09:15:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 08:21:05.000000"),
            },

            new
            {
                  Id = 74, Series = "SLCWH-00070-25", WarehouseId = 2, TransportCompany = "VIA LALAMOVE", Shipper = "SUNRISE TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-10 00:00:00.000000"), Reference = "1", PlateNumber = "ABC 123", DriverName = "NANTE MABINI",
                  DateTime = Convert.ToDateTime("2025-06-10 10:28:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-10 10:28:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-10 10:35:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-11 08:42:23.000000"),
            },

            new
            {
                  Id = 75, Series = "SLCWH-00071-25", WarehouseId = 1, TransportCompany = "ZESTO CORPORATION / JHEAIN-6", Shipper = "EAST RIZAL TRADING", Consignee = "",
                  DateReceived =  Convert.ToDateTime("2025-06-18 02:02:55.000000"), Reference = "Z-MCPPG-0011", PlateNumber = "NAA 1320", DriverName = "MAGPILI WILLIAM MADRID",
                  DateTime = Convert.ToDateTime("2025-06-18 09:33:00.000000"), ClientRepresentative = "", CheckerName = "Timothy Ambrose Manalaysay",
                  TimeStart = Convert.ToDateTime("2025-06-18 09:33:00.000000"), TimeEnd = Convert.ToDateTime("2025-06-18 10:00:00.000000"),
                  DateAdded = Convert.ToDateTime("2025-06-18 02:06:37.000000"),
            }
      );

      modelBuilder.Entity<ReceivedProduct>().HasData(
            new
            {
                  Id = 1, ReceivingId = 1, ProductId = 30, Quantity = 400, CBM = "15.51", TotalWeight = "1400",
                  ExpirationDate = DateOnly.Parse("2026-01-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 2, ReceivingId = 1, ProductId = 31, Quantity = 200, CBM = "7.75", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2026-01-10"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 3, ReceivingId = 1, ProductId = 32, Quantity = 600, CBM = "23.26", TotalWeight = "2100",
                  ExpirationDate = DateOnly.Parse("2026-01-10"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 4, ReceivingId = 2, ProductId = 17, Quantity = 288, CBM = "15.48", TotalWeight = "1008",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 5, ReceivingId = 3, ProductId = 4, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 6, ReceivingId = 3, ProductId = 6, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 7, ReceivingId = 4, ProductId = 17, Quantity = 216, CBM = "11.61", TotalWeight = "756",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 8, ReceivingId = 5, ProductId = 17, Quantity = 232, CBM = "12.47", TotalWeight = "812",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 10, ReceivingId = 6, ProductId = 11, Quantity = 300, CBM = "16.13", TotalWeight = "1050",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 11, ReceivingId = 6, ProductId = 2, Quantity = 171, CBM = "5.91", TotalWeight = "598.5",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 12, ReceivingId = 7, ProductId = 15, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 13, ReceivingId = 7, ProductId = 17, Quantity = 144, CBM = "7.74", TotalWeight = "504",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 14, ReceivingId = 8, ProductId = 2, Quantity = 19, CBM = "0.66", TotalWeight = "66.5",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 15, ReceivingId = 8, ProductId = 13, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2025-01-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 16, ReceivingId = 8, ProductId = 14, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 17, ReceivingId = 9, ProductId = 17, Quantity = 120, CBM = "6.45", TotalWeight = "420",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 18, ReceivingId = 9, ProductId = 12, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 19, ReceivingId = 10, ProductId = 7, Quantity = 318, CBM = "17.1", TotalWeight = "1113",
                  ExpirationDate = DateOnly.Parse("2026-01-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 20, ReceivingId = 11, ProductId = 1, Quantity = 200, CBM = "6.91", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2026-01-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 21, ReceivingId = 11, ProductId = 24, Quantity = 200, CBM = "10.75", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2026-01-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 22, ReceivingId = 11, ProductId = 2, Quantity = 10, CBM = "0.35", TotalWeight = "35",
                  ExpirationDate = DateOnly.Parse("2026-01-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 23, ReceivingId = 12, ProductId = 7, Quantity = 247, CBM = "13.28", TotalWeight = "864.5",
                  ExpirationDate = DateOnly.Parse("2026-01-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 24, ReceivingId = 13, ProductId = 18, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 25, ReceivingId = 13, ProductId = 19, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 26, ReceivingId = 13, ProductId = 20, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 27, ReceivingId = 14, ProductId = 3, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 28, ReceivingId = 14, ProductId = 7, Quantity = 35, CBM = "1.88", TotalWeight = "122.5",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 29, ReceivingId = 14, ProductId = 22, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 30, ReceivingId = 14, ProductId = 23, Quantity = 12, CBM = "0.65", TotalWeight = "42",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 37, ReceivingId = 18, ProductId = 41, Quantity = 50, CBM = "0.56", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2025-10-10"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 1,
            },
            new
            {
                  Id = 38, ReceivingId = 18, ProductId = 42, Quantity = 49, CBM = "0.55", TotalWeight = "147",
                  ExpirationDate = DateOnly.Parse("2025-09-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 1,
            },
            new
            {
                  Id = 39, ReceivingId = 19, ProductId = 45, Quantity = 50, CBM = "0.56", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2025-09-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 2,
            },
            new
            {
                  Id = 40, ReceivingId = 19, ProductId = 46, Quantity = 50, CBM = "0.56", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2025-10-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 2,
            },
            new
            {
                  Id = 41, ReceivingId = 20, ProductId = 43, Quantity = 46, CBM = "0.52", TotalWeight = "138",
                  ExpirationDate = DateOnly.Parse("2025-10-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 3,
            },
            new
            {
                  Id = 42, ReceivingId = 20, ProductId = 44, Quantity = 50, CBM = "0.56", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2025-10-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 3,
            },
            new
            {
                  Id = 43, ReceivingId = 21, ProductId = 33, Quantity = 1, CBM = "0.13", TotalWeight = "0",
                  ExpirationDate = DateOnly.Parse("2025-01-25"),
                  Remarks = "CONTROLLER-3PCS",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 44, ReceivingId = 21, ProductId = 34, Quantity = 1, CBM = "0.03", TotalWeight = "0",
                  ExpirationDate = DateOnly.Parse("2025-01-25"),
                  Remarks = @"CIRCUIT BOARD(TS26F)-10PCS
                  CONTROLLER-3PCS
                  CONTROLLER(NEW)-3PCS
                  SENSORS-18PCS
                  CPR(WITH O-RING)-3PCS
                  FUSE DETECTION BOARD(TS55F)-5PCS",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 45, ReceivingId = 21, ProductId = 38, Quantity = 8, CBM = "0.27", TotalWeight = "0",
                  ExpirationDate = DateOnly.Parse("2025-01-25"),
                  Remarks = "16SETS",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 46, ReceivingId = 21, ProductId = 37, Quantity = 1, CBM = "0", TotalWeight = "0",
                  ExpirationDate = DateOnly.Parse("2025-01-25"),
                  Remarks = "6SET - 3SETS OF BY 3's AND 3SETS OF BY 2's",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 47, ReceivingId = 22, ProductId = 32, Quantity = 600, CBM = "23.26", TotalWeight = "2100",
                  ExpirationDate = DateOnly.Parse("2026-02-25"),
                  Remarks = "Good Condition",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 48, ReceivingId = 22, ProductId = 30, Quantity = 400, CBM = "15.51", TotalWeight = "1400",
                  ExpirationDate = DateOnly.Parse("2026-02-25"),
                  Remarks = "Good Condition",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 49, ReceivingId = 22, ProductId = 31, Quantity = 200, CBM = "7.75", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2026-02-25"),
                  Remarks = "Good Condition",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 50, ReceivingId = 23, ProductId = 17, Quantity = 747, CBM = "40.16", TotalWeight = "2614.5",
                  ExpirationDate = DateOnly.Parse("2026-02-14"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 51, ReceivingId = 23, ProductId = 11, Quantity = 15, CBM = "0.81", TotalWeight = "52.5",
                  ExpirationDate = DateOnly.Parse("2026-02-10"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 52, ReceivingId = 24, ProductId = 17, Quantity = 20, CBM = "1.08", TotalWeight = "70",
                  ExpirationDate = DateOnly.Parse("2026-02-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 53, ReceivingId = 24, ProductId = 12, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-02-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 54, ReceivingId = 24, ProductId = 7, Quantity = 125, CBM = "6.72", TotalWeight = "437.5",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 55, ReceivingId = 25, ProductId = 7, Quantity = 270, CBM = "14.52", TotalWeight = "945",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 56, ReceivingId = 26, ProductId = 7, Quantity = 205, CBM = "11.02", TotalWeight = "717.5",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 57, ReceivingId = 27, ProductId = 18, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2026-02-07"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 4,
            },
            new
            {
                  Id = 58, ReceivingId = 27, ProductId = 20, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2026-02-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 5,
            },
            new
            {
                  Id = 59, ReceivingId = 27, ProductId = 19, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2025-12-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 7,
            },
            new
            {
                  Id = 60, ReceivingId = 28, ProductId = 11, Quantity = 285, CBM = "15.32", TotalWeight = "997.5",
                  ExpirationDate = DateOnly.Parse("2026-02-10"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 61, ReceivingId = 29, ProductId = 17, Quantity = 233, CBM = "12.53", TotalWeight = "815.5",
                  ExpirationDate = DateOnly.Parse("2026-02-14"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 62, ReceivingId = 30, ProductId = 24, Quantity = 39, CBM = "2.1", TotalWeight = "136.5",
                  ExpirationDate = DateOnly.Parse("2026-02-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 8,
            },
            new
            {
                  Id = 63, ReceivingId = 30, ProductId = 23, Quantity = 15, CBM = "0.81", TotalWeight = "52.5",
                  ExpirationDate = DateOnly.Parse("2026-02-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 10,
            },
            new
            {
                  Id = 64, ReceivingId = 30, ProductId = 23, Quantity = 15, CBM = "0.81", TotalWeight = "52.5",
                  ExpirationDate = DateOnly.Parse("2026-02-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 11,
            },
            new
            {
                  Id = 65, ReceivingId = 30, ProductId = 23, Quantity = 20, CBM = "1.08", TotalWeight = "70",
                  ExpirationDate = DateOnly.Parse("2026-02-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 13,
            },
            new
            {
                  Id = 66, ReceivingId = 30, ProductId = 21, Quantity = 2, CBM = "0.11", TotalWeight = "7",
                  ExpirationDate = DateOnly.Parse("2026-02-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 14,
            },
            new
            {
                  Id = 67, ReceivingId = 30, ProductId = 4, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 15,
            },
            new
            {
                  Id = 68, ReceivingId = 30, ProductId = 4, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 16,
            },
            new
            {
                  Id = 69, ReceivingId = 30, ProductId = 6, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 17,
            },
            new
            {
                  Id = 70, ReceivingId = 30, ProductId = 6, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 18,
            },
            new
            {
                  Id = 71, ReceivingId = 30, ProductId = 3, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 19,
            },
            new
            {
                  Id = 72, ReceivingId = 30, ProductId = 3, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-02-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 20,
            },
            new
            {
                  Id = 73, ReceivingId = 31, ProductId = 13, Quantity = 72, CBM = "3.87", TotalWeight = "252",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 74, ReceivingId = 31, ProductId = 14, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-02-07"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 75, ReceivingId = 31, ProductId = 15, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-02-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 76, ReceivingId = 32, ProductId = 13, Quantity = 28, CBM = "1.51", TotalWeight = "98",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 77, ReceivingId = 32, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-02-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 21,
            },
            new
            {
                  Id = 78, ReceivingId = 32, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 22,
            },
            new
            {
                  Id = 79, ReceivingId = 32, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 23,
            },
            new
            {
                  Id = 80, ReceivingId = 32, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 24,
            },
            new
            {
                  Id = 81, ReceivingId = 32, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 25,
            },
            new
            {
                  Id = 82, ReceivingId = 32, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 26,
            },
            new
            {
                  Id = 83, ReceivingId = 32, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 27,
            },
            new
            {
                  Id = 84, ReceivingId = 32, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-03-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 28,
            },
            new
            {
                  Id = 85, ReceivingId = 33, ProductId = 24, Quantity = 61, CBM = "3.28", TotalWeight = "213.5",
                  ExpirationDate = DateOnly.Parse("2025-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 29,
            },
            new
            {
                  Id = 86, ReceivingId = 33, ProductId = 24, Quantity = 60, CBM = "3.23", TotalWeight = "210",
                  ExpirationDate = DateOnly.Parse("2025-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 30,
            },
            new
            {
                  Id = 87, ReceivingId = 33, ProductId = 24, Quantity = 40, CBM = "2.15", TotalWeight = "140",
                  ExpirationDate = DateOnly.Parse("2025-03-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 31,
            },
            new
            {
                  Id = 88, ReceivingId = 33, ProductId = 48, Quantity = 100, CBM = "6.8", TotalWeight = "300",
                  ExpirationDate = DateOnly.Parse("2026-02-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 89, ReceivingId = 33, ProductId = 49, Quantity = 100, CBM = "9.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-02-18"),
                  Remarks = "WRONG FLAVOR ON INVOICE ORDER MUST BE MIGGOS SWEETCORN 105G",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 90, ReceivingId = 34, ProductId = 50, Quantity = 1, CBM = "0.05", TotalWeight = "7",
                  ExpirationDate = DateOnly.Parse("2025-03-11"),
                  Remarks = "A20221125002",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 91, ReceivingId = 34, ProductId = 51, Quantity = 1, CBM = "0.13", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221125028",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 92, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117020",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 93, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 94, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 95, ReceivingId = 34, ProductId = 54, Quantity = 1, CBM = "0.13", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221114003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 96, ReceivingId = 34, ProductId = 55, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20211115003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 97, ReceivingId = 34, ProductId = 55, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20211115008",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 98, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20231129001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 99, ReceivingId = 34, ProductId = 54, Quantity = 1, CBM = "0.13", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20231129001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 100, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117016",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 101, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 102, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117016",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 103, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 104, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117018",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 105, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122002",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 106, ReceivingId = 34, ProductId = 55, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20211115005",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 107, ReceivingId = 34, ProductId = 56, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20201112003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 108, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117021",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 109, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122004",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 110, ReceivingId = 34, ProductId = 50, Quantity = 1, CBM = "0.05", TotalWeight = "7",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221125001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 111, ReceivingId = 34, ProductId = 51, Quantity = 1, CBM = "0.13", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221125027",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 112, ReceivingId = 34, ProductId = 52, Quantity = 1, CBM = "0.05", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221117022",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 113, ReceivingId = 34, ProductId = 53, Quantity = 1, CBM = "0.13", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "A20221122005",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 114, ReceivingId = 34, ProductId = 56, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20201112002",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 115, ReceivingId = 34, ProductId = 56, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20201112004",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 116, ReceivingId = 34, ProductId = 57, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20240604001",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 117, ReceivingId = 34, ProductId = 57, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20240604002",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 118, ReceivingId = 34, ProductId = 57, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20240604003",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 119, ReceivingId = 34, ProductId = 55, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20211115006",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 120, ReceivingId = 34, ProductId = 56, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20201112009",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 121, ReceivingId = 34, ProductId = 55, Quantity = 1, CBM = "0.28", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-03-13"),
                  Remarks = "20211115007",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 122, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 398,
            },
            new
            {
                  Id = 123, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 399,
            },
            new
            {
                  Id = 124, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-06-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 400,
            },
            new
            {
                  Id = 125, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-06-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 401,
            },
            new
            {
                  Id = 126, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-06-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 402,
            },
            new
            {
                  Id = 127, ReceivingId = 35, ProductId = 58, Quantity = 30, CBM = "0", TotalWeight = "315",
                  ExpirationDate = DateOnly.Parse("2025-06-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 403,
            },
            new
            {
                  Id = 128, ReceivingId = 36, ProductId = 18, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2026-05-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 404,
            },
            new
            {
                  Id = 129, ReceivingId = 36, ProductId = 20, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2026-05-07"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 405,
            },
            new
            {
                  Id = 130, ReceivingId = 36, ProductId = 19, Quantity = 80, CBM = "4.3", TotalWeight = "280",
                  ExpirationDate = DateOnly.Parse("2026-05-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 406,
            },
            new
            {
                  Id = 131, ReceivingId = 37, ProductId = 17, Quantity = 500, CBM = "26.88", TotalWeight = "1750",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 132, ReceivingId = 37, ProductId = 49, Quantity = 100, CBM = "9.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 133, ReceivingId = 37, ProductId = 11, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 134, ReceivingId = 38, ProductId = 12, Quantity = 28, CBM = "1.51", TotalWeight = "98",
                  ExpirationDate = DateOnly.Parse("2026-04-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 135, ReceivingId = 38, ProductId = 11, Quantity = 150, CBM = "8.06", TotalWeight = "525",
                  ExpirationDate = DateOnly.Parse("2026-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 136, ReceivingId = 38, ProductId = 13, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-04-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 137, ReceivingId = 38, ProductId = 14, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-04-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 138, ReceivingId = 38, ProductId = 15, Quantity = 100, CBM = "5.38", TotalWeight = "350",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 139, ReceivingId = 39, ProductId = 6, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 407,
            },
            new
            {
                  Id = 140, ReceivingId = 39, ProductId = 4, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 408,
            },
            new
            {
                  Id = 141, ReceivingId = 39, ProductId = 3, Quantity = 50, CBM = "2.69", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 409,
            },
            new
            {
                  Id = 142, ReceivingId = 39, ProductId = 25, Quantity = 300, CBM = "16.13", TotalWeight = "1050",
                  ExpirationDate = DateOnly.Parse("2026-04-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 143, ReceivingId = 39, ProductId = 12, Quantity = 72, CBM = "3.87", TotalWeight = "252",
                  ExpirationDate = DateOnly.Parse("2026-04-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 144, ReceivingId = 39, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 410,
            },
            new
            {
                  Id = 145, ReceivingId = 39, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 411,
            },
            new
            {
                  Id = 146, ReceivingId = 39, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 412,
            },
            new
            {
                  Id = 147, ReceivingId = 39, ProductId = 1, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 413,
            },
            new
            {
                  Id = 148, ReceivingId = 39, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 414,
            },
            new
            {
                  Id = 149, ReceivingId = 39, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 415,
            },
            new
            {
                  Id = 150, ReceivingId = 39, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 416,
            },
            new
            {
                  Id = 151, ReceivingId = 39, ProductId = 2, Quantity = 50, CBM = "1.73", TotalWeight = "175",
                  ExpirationDate = DateOnly.Parse("2026-04-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 417,
            },
            new
            {
                  Id = 152, ReceivingId = 40, ProductId = 48, Quantity = 25, CBM = "1.7", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 423,
            },
            new
            {
                  Id = 153, ReceivingId = 40, ProductId = 48, Quantity = 25, CBM = "1.7", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 424,
            },
            new
            {
                  Id = 154, ReceivingId = 40, ProductId = 48, Quantity = 25, CBM = "1.7", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 425,
            },
            new
            {
                  Id = 155, ReceivingId = 40, ProductId = 48, Quantity = 25, CBM = "1.7", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 426,
            },
            new
            {
                  Id = 156, ReceivingId = 40, ProductId = 21, Quantity = 4, CBM = "0.22", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2026-04-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 427,
            },
            new
            {
                  Id = 157, ReceivingId = 40, ProductId = 23, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 428,
            },
            new
            {
                  Id = 158, ReceivingId = 40, ProductId = 23, Quantity = 25, CBM = "1.34", TotalWeight = "87.5",
                  ExpirationDate = DateOnly.Parse("2026-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 429,
            },
            new
            {
                  Id = 159, ReceivingId = 40, ProductId = 22, Quantity = 24, CBM = "1.29", TotalWeight = "84",
                  ExpirationDate = DateOnly.Parse("2026-04-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 430,
            },
            new
            {
                  Id = 160, ReceivingId = 41, ProductId = 60, Quantity = 20, CBM = "0.48", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2026-08-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 434,
            },
            new
            {
                  Id = 161, ReceivingId = 41, ProductId = 61, Quantity = 20, CBM = "0.5", TotalWeight = "180",
                  ExpirationDate = DateOnly.Parse("2026-07-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 434,
            },
            new
            {
                  Id = 162, ReceivingId = 41, ProductId = 62, Quantity = 30, CBM = "0.87", TotalWeight = "240",
                  ExpirationDate = DateOnly.Parse("2026-06-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 435,
            },
            new
            {
                  Id = 163, ReceivingId = 41, ProductId = 65, Quantity = 100, CBM = "0.96", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2026-05-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 436,
            },
            new
            {
                  Id = 164, ReceivingId = 42, ProductId = 63, Quantity = 20, CBM = "0.6", TotalWeight = "290",
                  ExpirationDate = DateOnly.Parse("2026-11-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 439,
            },
            new
            {
                  Id = 165, ReceivingId = 42, ProductId = 64, Quantity = 20, CBM = "0.46", TotalWeight = "230",
                  ExpirationDate = DateOnly.Parse("2027-03-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 440,
            },
            new
            {
                  Id = 166, ReceivingId = 43, ProductId = 32, Quantity = 500, CBM = "19.38", TotalWeight = "1000",
                  ExpirationDate = DateOnly.Parse("2026-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 167, ReceivingId = 43, ProductId = 30, Quantity = 300, CBM = "11.63", TotalWeight = "600",
                  ExpirationDate = DateOnly.Parse("2026-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 168, ReceivingId = 43, ProductId = 31, Quantity = 200, CBM = "7.75", TotalWeight = "400",
                  ExpirationDate = DateOnly.Parse("2026-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = (int?)null,
            },
            new
            {
                  Id = 169, ReceivingId = 44, ProductId = 66, Quantity = 15, CBM = "0.14", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2027-03-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 444,
            },
            new
            {
                  Id = 170, ReceivingId = 44, ProductId = 67, Quantity = 5, CBM = "0.05", TotalWeight = "5",
                  ExpirationDate = DateOnly.Parse("2025-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 444,
            },
            new
            {
                  Id = 171, ReceivingId = 44, ProductId = 68, Quantity = 10, CBM = "0.25", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2025-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 444,
            },
            new
            {
                  Id = 172, ReceivingId = 44, ProductId = 69, Quantity = 29, CBM = "0.49", TotalWeight = "362.5",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "1 CARTON FOR RETURN MISSING 2CANS. RECEIVED 29CARTONS ONLY",
                  ContainerName = string.Empty,
                  PalletId = 445,
            },
            new
            {
                  Id = 173, ReceivingId = 44, ProductId = 70, Quantity = 10, CBM = "0.13", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2025-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 444,
            },
            new
            {
                  Id = 174, ReceivingId = 44, ProductId = 71, Quantity = 10, CBM = "0.36", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2025-05-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 444,
            },
            new
            {
                  Id = 175, ReceivingId = 44, ProductId = 44, Quantity = 6, CBM = "0.07", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2026-02-08"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 446,
            },
            new
            {
                  Id = 176, ReceivingId = 44, ProductId = 72, Quantity = 12, CBM = "0.14", TotalWeight = "36",
                  ExpirationDate = DateOnly.Parse("2026-02-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 446,
            },
            new
            {
                  Id = 177, ReceivingId = 45, ProductId = 73, Quantity = 15, CBM = "0.39", TotalWeight = "307.5",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 447,
            },
            new
            {
                  Id = 178, ReceivingId = 46, ProductId = 41, Quantity = 76, CBM = "0.86", TotalWeight = "228",
                  ExpirationDate = DateOnly.Parse("2026-01-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 448,
            },
            new
            {
                  Id = 179, ReceivingId = 47, ProductId = 74, Quantity = 30, CBM = "0.34", TotalWeight = "90",
                  ExpirationDate = DateOnly.Parse("2026-01-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 449,
            },
            new
            {
                  Id = 180, ReceivingId = 47, ProductId = 42, Quantity = 50, CBM = "0.56", TotalWeight = "150",
                  ExpirationDate = DateOnly.Parse("2026-02-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 450,
            },
            new
            {
                  Id = 181, ReceivingId = 47, ProductId = 75, Quantity = 5, CBM = "0.06", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2026-02-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 449,
            },
            new
            {
                  Id = 182, ReceivingId = 48, ProductId = 76, Quantity = 10, CBM = "0.32", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 451,
            },
            new
            {
                  Id = 183, ReceivingId = 48, ProductId = 77, Quantity = 10, CBM = "0.32", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 451,
            },
            new
            {
                  Id = 184, ReceivingId = 49, ProductId = 78, Quantity = 100, CBM = "0.73", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2025-12-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 452,
            },
            new
            {
                  Id = 185, ReceivingId = 50, ProductId = 73, Quantity = 25, CBM = "0.65", TotalWeight = "512.5",
                  ExpirationDate = DateOnly.Parse("2026-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 457,
            },
            new
            {
                  Id = 186, ReceivingId = 50, ProductId = 73, Quantity = 25, CBM = "0.65", TotalWeight = "512.5",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 458,
            },
            new
            {
                  Id = 187, ReceivingId = 50, ProductId = 73, Quantity = 25, CBM = "0.65", TotalWeight = "512.5",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 459,
            },
            new
            {
                  Id = 188, ReceivingId = 50, ProductId = 73, Quantity = 25, CBM = "0.65", TotalWeight = "512.5",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 460,
            },
            new
            {
                  Id = 189, ReceivingId = 51, ProductId = 79, Quantity = 50, CBM = "0.98", TotalWeight = "575",
                  ExpirationDate = DateOnly.Parse("2026-03-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 461,
            },
            new
            {
                  Id = 190, ReceivingId = 51, ProductId = 79, Quantity = 25, CBM = "0.49", TotalWeight = "287.5",
                  ExpirationDate = DateOnly.Parse("2026-03-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 462,
            },
            new
            {
                  Id = 191, ReceivingId = 51, ProductId = 79, Quantity = 25, CBM = "0.49", TotalWeight = "287.5",
                  ExpirationDate = DateOnly.Parse("2026-03-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 463,
            },
            new
            {
                  Id = 192, ReceivingId = 52, ProductId = 80, Quantity = 20, CBM = "2.07", TotalWeight = "110",
                  ExpirationDate = DateOnly.Parse("2025-05-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 464,
            },
            new
            {
                  Id = 193, ReceivingId = 52, ProductId = 80, Quantity = 20, CBM = "2.07", TotalWeight = "110",
                  ExpirationDate = DateOnly.Parse("2025-05-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 465,
            },
            new
            {
                  Id = 194, ReceivingId = 53, ProductId = 81, Quantity = 25, CBM = "1.29", TotalWeight = "337.5",
                  ExpirationDate = DateOnly.Parse("2027-03-20"),
                  Remarks = "GOODS CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 466,
            },
            new
            {
                  Id = 195, ReceivingId = 53, ProductId = 81, Quantity = 25, CBM = "1.29", TotalWeight = "337.5",
                  ExpirationDate = DateOnly.Parse("2027-03-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 467,
            },
            new
            {
                  Id = 196, ReceivingId = 54, ProductId = 82, Quantity = 25, CBM = "0.38", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2025-05-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 468,
            },
            new
            {
                  Id = 197, ReceivingId = 54, ProductId = 82, Quantity = 25, CBM = "0.38", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-05-05"),
                  Remarks = "good condition",
                  ContainerName = string.Empty,
                  PalletId = 469,
            },
            new
            {
                  Id = 198, ReceivingId = 54, ProductId = 82, Quantity = 25, CBM = "0.38", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-05-05"),
                  Remarks = "Good Condition",
                  ContainerName = string.Empty,
                  PalletId = 470,
            },
            new
            {
                  Id = 199, ReceivingId = 54, ProductId = 82, Quantity = 25, CBM = "0.38", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2026-05-05"),
                  Remarks = "Good condition",
                  ContainerName = string.Empty,
                  PalletId = 471,
            },
            new
            {
                  Id = 201, ReceivingId = 55, ProductId = 83, Quantity = 30, CBM = "1.47", TotalWeight = "450",
                  ExpirationDate = DateOnly.Parse("2026-12-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 472,
            },
            new
            {
                  Id = 202, ReceivingId = 56, ProductId = 84, Quantity = 200, CBM = "0.63", TotalWeight = "400",
                  ExpirationDate = DateOnly.Parse("2025-11-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 477,
            },
            new
            {
                  Id = 203, ReceivingId = 56, ProductId = 85, Quantity = 333, CBM = "1.05", TotalWeight = "666",
                  ExpirationDate = DateOnly.Parse("2025-11-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 478,
            },
            new
            {
                  Id = 204, ReceivingId = 57, ProductId = 86, Quantity = 15, CBM = "0.59", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2025-11-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 480,
            },
            new
            {
                  Id = 205, ReceivingId = 57, ProductId = 88, Quantity = 5, CBM = "0.13", TotalWeight = "62.5",
                  ExpirationDate = DateOnly.Parse("2025-11-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 480,
            },
            new
            {
                  Id = 206, ReceivingId = 57, ProductId = 87, Quantity = 5, CBM = "0.17", TotalWeight = "10",
                  ExpirationDate = DateOnly.Parse("2025-11-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 480,
            },
            new
            {
                  Id = 207, ReceivingId = 58, ProductId = 89, Quantity = 40, CBM = "1.11", TotalWeight = "160",
                  ExpirationDate = DateOnly.Parse("2026-11-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 481,
            },
            new
            {
                  Id = 208, ReceivingId = 59, ProductId = 90, Quantity = 6, CBM = "1.03", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2025-05-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 482,
            },
            new
            {
                  Id = 209, ReceivingId = 59, ProductId = 91, Quantity = 6, CBM = "1.98", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2025-05-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 483,
            },
            new
            {
                  Id = 210, ReceivingId = 59, ProductId = 91, Quantity = 6, CBM = "1.98", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2025-05-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 484,
            },
            new
            {
                  Id = 211, ReceivingId = 60, ProductId = 90, Quantity = 6, CBM = "1.03", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2025-05-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 485,
            },
            new
            {
                  Id = 212, ReceivingId = 60, ProductId = 92, Quantity = 20, CBM = "8.15", TotalWeight = "230",
                  ExpirationDate = DateOnly.Parse("2025-05-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 486,
            },
            new
            {
                  Id = 232, ReceivingId = 62, ProductId = 121, Quantity = 10, CBM = "0.14", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2026-04-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 233, ReceivingId = 62, ProductId = 133, Quantity = 3, CBM = "0.16", TotalWeight = "27",
                  ExpirationDate = DateOnly.Parse("2025-10-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 234, ReceivingId = 62, ProductId = 96, Quantity = 3, CBM = "0.1", TotalWeight = "27",
                  ExpirationDate = DateOnly.Parse("2025-10-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 235, ReceivingId = 62, ProductId = 134, Quantity = 3, CBM = "0.03", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2025-12-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 236, ReceivingId = 62, ProductId = 106, Quantity = 10, CBM = "0.31", TotalWeight = "10",
                  ExpirationDate = DateOnly.Parse("2025-10-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 237, ReceivingId = 62, ProductId = 118, Quantity = 10, CBM = "0.43", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2025-10-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 238, ReceivingId = 62, ProductId = 136, Quantity = 10, CBM = "0.7", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2025-10-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 239, ReceivingId = 62, ProductId = 137, Quantity = 4, CBM = "0.31", TotalWeight = "8",
                  ExpirationDate = DateOnly.Parse("2025-11-07"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 240, ReceivingId = 62, ProductId = 138, Quantity = 5, CBM = "0.05", TotalWeight = "5",
                  ExpirationDate = DateOnly.Parse("2025-10-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 241, ReceivingId = 62, ProductId = 140, Quantity = 3, CBM = "0.08", TotalWeight = "3",
                  ExpirationDate = DateOnly.Parse("2025-11-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 242, ReceivingId = 62, ProductId = 119, Quantity = 8, CBM = "0.42", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-10-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 243, ReceivingId = 62, ProductId = 104, Quantity = 10, CBM = "0.16", TotalWeight = "130",
                  ExpirationDate = DateOnly.Parse("2026-04-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 244, ReceivingId = 62, ProductId = 128, Quantity = 25, CBM = "1.18", TotalWeight = "400",
                  ExpirationDate = DateOnly.Parse("2025-12-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 497,
            },
            new
            {
                  Id = 245, ReceivingId = 62, ProductId = 93, Quantity = 20, CBM = "0.36", TotalWeight = "220",
                  ExpirationDate = DateOnly.Parse("2027-03-14"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 498,
            },
            new
            {
                  Id = 246, ReceivingId = 62, ProductId = 105, Quantity = 5, CBM = "0.07", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2026-04-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 498,
            },
            new
            {
                  Id = 247, ReceivingId = 62, ProductId = 127, Quantity = 10, CBM = "0.55", TotalWeight = "140",
                  ExpirationDate = DateOnly.Parse("2027-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 498,
            },
            new
            {
                  Id = 248, ReceivingId = 62, ProductId = 123, Quantity = 13, CBM = "0.36", TotalWeight = "156",
                  ExpirationDate = DateOnly.Parse("2027-03-08"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 499,
            },
            new
            {
                  Id = 249, ReceivingId = 62, ProductId = 107, Quantity = 30, CBM = "0.84", TotalWeight = "480",
                  ExpirationDate = DateOnly.Parse("2026-04-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 499,
            },
            new
            {
                  Id = 250, ReceivingId = 62, ProductId = 97, Quantity = 50, CBM = "1.26", TotalWeight = "1000",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 500,
            },
            new
            {
                  Id = 251, ReceivingId = 62, ProductId = 97, Quantity = 50, CBM = "1.26", TotalWeight = "1000",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 501,
            },
            new
            {
                  Id = 252, ReceivingId = 63, ProductId = 100, Quantity = 50, CBM = "0.94", TotalWeight = "950",
                  ExpirationDate = DateOnly.Parse("2026-04-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 520,
            },
            new
            {
                  Id = 253, ReceivingId = 63, ProductId = 99, Quantity = 50, CBM = "0.78", TotalWeight = "750",
                  ExpirationDate = DateOnly.Parse("2026-04-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 521,
            },
            new
            {
                  Id = 254, ReceivingId = 63, ProductId = 101, Quantity = 50, CBM = "1.04", TotalWeight = "800",
                  ExpirationDate = DateOnly.Parse("2026-04-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 522,
            },
            new
            {
                  Id = 255, ReceivingId = 63, ProductId = 139, Quantity = 5, CBM = "0.16", TotalWeight = "5",
                  ExpirationDate = DateOnly.Parse("2025-11-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 256, ReceivingId = 63, ProductId = 123, Quantity = 3, CBM = "0.08", TotalWeight = "36",
                  ExpirationDate = DateOnly.Parse("2027-03-08"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 257, ReceivingId = 63, ProductId = 126, Quantity = 2, CBM = "0.04", TotalWeight = "26",
                  ExpirationDate = DateOnly.Parse("2026-02-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 258, ReceivingId = 63, ProductId = 95, Quantity = 5, CBM = "0.17", TotalWeight = "45",
                  ExpirationDate = DateOnly.Parse("2025-11-08"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 259, ReceivingId = 63, ProductId = 98, Quantity = 10, CBM = "0.32", TotalWeight = "70",
                  ExpirationDate = DateOnly.Parse("2026-09-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 260, ReceivingId = 63, ProductId = 102, Quantity = 3, CBM = "0.03", TotalWeight = "27",
                  ExpirationDate = DateOnly.Parse("2026-04-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 523,
            },
            new
            {
                  Id = 261, ReceivingId = 63, ProductId = 129, Quantity = 10, CBM = "0.25", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 262, ReceivingId = 63, ProductId = 129, Quantity = 10, CBM = "0.25", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 263, ReceivingId = 63, ProductId = 77, Quantity = 5, CBM = "0.16", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 264, ReceivingId = 63, ProductId = 111, Quantity = 5, CBM = "0.79", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 265, ReceivingId = 63, ProductId = 117, Quantity = 5, CBM = "0.02", TotalWeight = "10",
                  ExpirationDate = DateOnly.Parse("2029-03-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 266, ReceivingId = 63, ProductId = 76, Quantity = 5, CBM = "0.16", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 267, ReceivingId = 63, ProductId = 109, Quantity = 5, CBM = "0.21", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-12-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 268, ReceivingId = 63, ProductId = 115, Quantity = 3, CBM = "0.09", TotalWeight = "27",
                  ExpirationDate = DateOnly.Parse("2026-03-31"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 269, ReceivingId = 63, ProductId = 113, Quantity = 2, CBM = "0.03", TotalWeight = "8",
                  ExpirationDate = DateOnly.Parse("2026-06-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 270, ReceivingId = 63, ProductId = 114, Quantity = 3, CBM = "0.03", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2026-09-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 271, ReceivingId = 63, ProductId = 108, Quantity = 20, CBM = "0.65", TotalWeight = "320",
                  ExpirationDate = DateOnly.Parse("2026-02-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 524,
            },
            new
            {
                  Id = 272, ReceivingId = 63, ProductId = 132, Quantity = 2, CBM = "0.04", TotalWeight = "32",
                  ExpirationDate = DateOnly.Parse("2027-02-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 273, ReceivingId = 63, ProductId = 122, Quantity = 2, CBM = "0.02", TotalWeight = "13",
                  ExpirationDate = DateOnly.Parse("2025-10-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 274, ReceivingId = 63, ProductId = 125, Quantity = 5, CBM = "0.1", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2026-08-23"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 275, ReceivingId = 63, ProductId = 103, Quantity = 2, CBM = "0.05", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2026-04-15"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 276, ReceivingId = 63, ProductId = 120, Quantity = 10, CBM = "0.52", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-10-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 277, ReceivingId = 63, ProductId = 130, Quantity = 10, CBM = "0.25", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2025-12-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 278, ReceivingId = 63, ProductId = 12, Quantity = 10, CBM = "0.54", TotalWeight = "35",
                  ExpirationDate = DateOnly.Parse("2025-10-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 279, ReceivingId = 63, ProductId = 112, Quantity = 15, CBM = "0.54", TotalWeight = "120",
                  ExpirationDate = DateOnly.Parse("2025-10-22"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 525,
            },
            new
            {
                  Id = 280, ReceivingId = 64, ProductId = 141, Quantity = 15, CBM = "0.73", TotalWeight = "405",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 530,
            },
            new
            {
                  Id = 281, ReceivingId = 64, ProductId = 150, Quantity = 5, CBM = "0.15", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 530,
            },
            new
            {
                  Id = 282, ReceivingId = 64, ProductId = 151, Quantity = 5, CBM = "0.15", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 530,
            },
            new
            {
                  Id = 283, ReceivingId = 64, ProductId = 145, Quantity = 2, CBM = "0.05", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2027-02-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 530,
            },
            new
            {
                  Id = 284, ReceivingId = 64, ProductId = 142, Quantity = 15, CBM = "0.73", TotalWeight = "405",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 531,
            },
            new
            {
                  Id = 285, ReceivingId = 64, ProductId = 147, Quantity = 3, CBM = "0.03", TotalWeight = "42",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 531,
            },
            new
            {
                  Id = 286, ReceivingId = 64, ProductId = 148, Quantity = 3, CBM = "0.03", TotalWeight = "39",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 531,
            },
            new
            {
                  Id = 287, ReceivingId = 64, ProductId = 146, Quantity = 5, CBM = "0.05", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 531,
            },
            new
            {
                  Id = 288, ReceivingId = 64, ProductId = 149, Quantity = 5, CBM = "0.05", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 531,
            },
            new
            {
                  Id = 289, ReceivingId = 64, ProductId = 143, Quantity = 15, CBM = "0.73", TotalWeight = "405",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 532,
            },
            new
            {
                  Id = 290, ReceivingId = 64, ProductId = 144, Quantity = 25, CBM = "1.22", TotalWeight = "675",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 533,
            },
            new
            {
                  Id = 291, ReceivingId = 65, ProductId = 152, Quantity = 53, CBM = "1.65", TotalWeight = "1060",
                  ExpirationDate = DateOnly.Parse("2026-11-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 534,
            },
            new
            {
                  Id = 292, ReceivingId = 65, ProductId = 152, Quantity = 34, CBM = "1.06", TotalWeight = "680",
                  ExpirationDate = DateOnly.Parse("2026-11-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 535,
            },
            new
            {
                  Id = 293, ReceivingId = 65, ProductId = 153, Quantity = 18, CBM = "0.56", TotalWeight = "360",
                  ExpirationDate = DateOnly.Parse("2026-11-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 535,
            },
            new
            {
                  Id = 294, ReceivingId = 65, ProductId = 153, Quantity = 52, CBM = "1.62", TotalWeight = "1040",
                  ExpirationDate = DateOnly.Parse("2026-11-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 536,
            },
            new
            {
                  Id = 295, ReceivingId = 66, ProductId = 165, Quantity = 15, CBM = "0.73", TotalWeight = "90",
                  ExpirationDate = DateOnly.Parse("2027-01-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 296, ReceivingId = 66, ProductId = 128, Quantity = 10, CBM = "0.47", TotalWeight = "160",
                  ExpirationDate = DateOnly.Parse("2027-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 297, ReceivingId = 66, ProductId = 103, Quantity = 6, CBM = "0.14", TotalWeight = "48",
                  ExpirationDate = DateOnly.Parse("2026-04-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 298, ReceivingId = 66, ProductId = 167, Quantity = 3, CBM = "0.05", TotalWeight = "33",
                  ExpirationDate = DateOnly.Parse("2027-05-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 299, ReceivingId = 66, ProductId = 171, Quantity = 3, CBM = "0.03", TotalWeight = "37.5",
                  ExpirationDate = DateOnly.Parse("2025-06-04"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 300, ReceivingId = 66, ProductId = 102, Quantity = 5, CBM = "0.06", TotalWeight = "45",
                  ExpirationDate = DateOnly.Parse("2026-04-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 301, ReceivingId = 66, ProductId = 158, Quantity = 6, CBM = "0.12", TotalWeight = "36",
                  ExpirationDate = DateOnly.Parse("2026-04-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 302, ReceivingId = 66, ProductId = 155, Quantity = 4, CBM = "0.09", TotalWeight = "48",
                  ExpirationDate = DateOnly.Parse("2027-03-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 303, ReceivingId = 66, ProductId = 168, Quantity = 2, CBM = "0.04", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2027-04-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 304, ReceivingId = 66, ProductId = 166, Quantity = 5, CBM = "0.13", TotalWeight = "75",
                  ExpirationDate = DateOnly.Parse("2027-05-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 542,
            },
            new
            {
                  Id = 305, ReceivingId = 66, ProductId = 134, Quantity = 6, CBM = "0.06", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2025-11-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 306, ReceivingId = 66, ProductId = 130, Quantity = 5, CBM = "0.12", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2026-01-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 307, ReceivingId = 66, ProductId = 131, Quantity = 5, CBM = "0.12", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2026-01-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 308, ReceivingId = 66, ProductId = 129, Quantity = 5, CBM = "0.12", TotalWeight = "25",
                  ExpirationDate = DateOnly.Parse("2026-01-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 309, ReceivingId = 66, ProductId = 169, Quantity = 1, CBM = "0.04", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2026-11-09"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 310, ReceivingId = 66, ProductId = 161, Quantity = 1, CBM = "0.04", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2026-10-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 311, ReceivingId = 66, ProductId = 154, Quantity = 1, CBM = "0.04", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2026-10-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 312, ReceivingId = 66, ProductId = 170, Quantity = 1, CBM = "0.03", TotalWeight = "7",
                  ExpirationDate = DateOnly.Parse("2027-02-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 313, ReceivingId = 66, ProductId = 160, Quantity = 2, CBM = "0.05", TotalWeight = "14",
                  ExpirationDate = DateOnly.Parse("2027-02-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 543,
            },
            new
            {
                  Id = 314, ReceivingId = 66, ProductId = 97, Quantity = 35, CBM = "0.89", TotalWeight = "700",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 544,
            },
            new
            {
                  Id = 315, ReceivingId = 66, ProductId = 159, Quantity = 15, CBM = "0.36", TotalWeight = "285",
                  ExpirationDate = DateOnly.Parse("2025-11-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 545,
            },
            new
            {
                  Id = 316, ReceivingId = 66, ProductId = 162, Quantity = 10, CBM = "0.24", TotalWeight = "190",
                  ExpirationDate = DateOnly.Parse("2025-10-12"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 545,
            },
            new
            {
                  Id = 317, ReceivingId = 66, ProductId = 156, Quantity = 10, CBM = "0.24", TotalWeight = "190",
                  ExpirationDate = DateOnly.Parse("2025-10-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 545,
            },
            new
            {
                  Id = 318, ReceivingId = 66, ProductId = 157, Quantity = 10, CBM = "0.2", TotalWeight = "190",
                  ExpirationDate = DateOnly.Parse("2025-09-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 546,
            },
            new
            {
                  Id = 319, ReceivingId = 66, ProductId = 164, Quantity = 15, CBM = "0.3", TotalWeight = "180",
                  ExpirationDate = DateOnly.Parse("2025-11-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 546,
            },
            new
            {
                  Id = 320, ReceivingId = 66, ProductId = 163, Quantity = 15, CBM = "0.17", TotalWeight = "135",
                  ExpirationDate = DateOnly.Parse("2025-10-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 546,
            },
            new
            {
                  Id = 321, ReceivingId = 67, ProductId = 174, Quantity = 50, CBM = "0.27", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 547,
            },
            new
            {
                  Id = 322, ReceivingId = 67, ProductId = 172, Quantity = 50, CBM = "0.27", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 547,
            },
            new
            {
                  Id = 323, ReceivingId = 67, ProductId = 175, Quantity = 50, CBM = "0.27", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 547,
            },
            new
            {
                  Id = 324, ReceivingId = 67, ProductId = 173, Quantity = 50, CBM = "0.27", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2025-12-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 547,
            },
            new
            {
                  Id = 325, ReceivingId = 68, ProductId = 176, Quantity = 5, CBM = "0.09", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2027-04-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 326, ReceivingId = 68, ProductId = 177, Quantity = 3, CBM = "0.05", TotalWeight = "57",
                  ExpirationDate = DateOnly.Parse("2027-05-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 327, ReceivingId = 68, ProductId = 178, Quantity = 2, CBM = "0.01", TotalWeight = "8",
                  ExpirationDate = DateOnly.Parse("2027-03-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 328, ReceivingId = 68, ProductId = 179, Quantity = 2, CBM = "0.03", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2027-06-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 329, ReceivingId = 68, ProductId = 181, Quantity = 4, CBM = "0.04", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2027-03-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 330, ReceivingId = 68, ProductId = 182, Quantity = 3, CBM = "0.04", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2027-05-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 331, ReceivingId = 68, ProductId = 183, Quantity = 1, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-11-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 332, ReceivingId = 68, ProductId = 184, Quantity = 1, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-02-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 333, ReceivingId = 68, ProductId = 185, Quantity = 2, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-01-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 334, ReceivingId = 69, ProductId = 176, Quantity = 5, CBM = "0.09", TotalWeight = "100",
                  ExpirationDate = DateOnly.Parse("2027-04-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 335, ReceivingId = 69, ProductId = 177, Quantity = 3, CBM = "0.05", TotalWeight = "57",
                  ExpirationDate = DateOnly.Parse("2027-05-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 336, ReceivingId = 69, ProductId = 178, Quantity = 2, CBM = "0.01", TotalWeight = "8",
                  ExpirationDate = DateOnly.Parse("2027-03-16"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 337, ReceivingId = 69, ProductId = 179, Quantity = 2, CBM = "0.03", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2027-06-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 338, ReceivingId = 69, ProductId = 181, Quantity = 4, CBM = "0.04", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2027-03-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 339, ReceivingId = 69, ProductId = 182, Quantity = 3, CBM = "0.04", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2027-05-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 340, ReceivingId = 69, ProductId = 183, Quantity = 1, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-11-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 341, ReceivingId = 69, ProductId = 184, Quantity = 1, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-02-27"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 342, ReceivingId = 69, ProductId = 185, Quantity = 2, CBM = "0.01", TotalWeight = "2",
                  ExpirationDate = DateOnly.Parse("2027-01-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 548,
            },
            new
            {
                  Id = 343, ReceivingId = 70, ProductId = 186, Quantity = 6, CBM = "0.51", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 344, ReceivingId = 70, ProductId = 187, Quantity = 6, CBM = "0.51", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 345, ReceivingId = 70, ProductId = 188, Quantity = 5, CBM = "0.42", TotalWeight = "15",
                  ExpirationDate = DateOnly.Parse("2027-11-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 346, ReceivingId = 70, ProductId = 189, Quantity = 8, CBM = "0.18", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2026-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 347, ReceivingId = 70, ProductId = 190, Quantity = 6, CBM = "0.13", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2026-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 348, ReceivingId = 70, ProductId = 191, Quantity = 6, CBM = "0.13", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2026-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 349, ReceivingId = 70, ProductId = 192, Quantity = 5, CBM = "0.13", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2026-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 350, ReceivingId = 70, ProductId = 193, Quantity = 5, CBM = "0.13", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2026-11-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 351, ReceivingId = 70, ProductId = 194, Quantity = 5, CBM = "0.13", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2026-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 352, ReceivingId = 70, ProductId = 204, Quantity = 1, CBM = "0.02", TotalWeight = "3",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 549,
            },
            new
            {
                  Id = 353, ReceivingId = 70, ProductId = 195, Quantity = 8, CBM = "0.1", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 354, ReceivingId = 70, ProductId = 196, Quantity = 8, CBM = "0.1", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 355, ReceivingId = 70, ProductId = 197, Quantity = 8, CBM = "0.1", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 356, ReceivingId = 70, ProductId = 198, Quantity = 8, CBM = "0.1", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 357, ReceivingId = 70, ProductId = 199, Quantity = 5, CBM = "0.06", TotalWeight = "10",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 358, ReceivingId = 70, ProductId = 201, Quantity = 3, CBM = "0.15", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 359, ReceivingId = 70, ProductId = 202, Quantity = 3, CBM = "0.15", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 360, ReceivingId = 70, ProductId = 203, Quantity = 2, CBM = "0.1", TotalWeight = "6",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 361, ReceivingId = 70, ProductId = 205, Quantity = 6, CBM = "0.59", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2026-06-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 362, ReceivingId = 70, ProductId = 206, Quantity = 6, CBM = "0.36", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2026-06-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 550,
            },
            new
            {
                  Id = 363, ReceivingId = 71, ProductId = 208, Quantity = 8, CBM = "0.61", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 364, ReceivingId = 71, ProductId = 209, Quantity = 6, CBM = "0.46", TotalWeight = "0",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 365, ReceivingId = 71, ProductId = 210, Quantity = 8, CBM = "0.57", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 366, ReceivingId = 71, ProductId = 211, Quantity = 8, CBM = "0.57", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 367, ReceivingId = 71, ProductId = 212, Quantity = 6, CBM = "0.32", TotalWeight = "18",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 368, ReceivingId = 71, ProductId = 213, Quantity = 8, CBM = "0.42", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 369, ReceivingId = 71, ProductId = 214, Quantity = 8, CBM = "0.42", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-24"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 551,
            },
            new
            {
                  Id = 370, ReceivingId = 71, ProductId = 215, Quantity = 3, CBM = "0.16", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2025-12-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 371, ReceivingId = 71, ProductId = 216, Quantity = 3, CBM = "0.16", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2025-12-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 372, ReceivingId = 71, ProductId = 217, Quantity = 3, CBM = "0.16", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2025-11-13"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 373, ReceivingId = 71, ProductId = 218, Quantity = 8, CBM = "0.4", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-11-21"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 374, ReceivingId = 71, ProductId = 219, Quantity = 8, CBM = "0.4", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-11-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 375, ReceivingId = 71, ProductId = 221, Quantity = 3, CBM = "0.23", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2025-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 376, ReceivingId = 71, ProductId = 222, Quantity = 3, CBM = "0.23", TotalWeight = "9",
                  ExpirationDate = DateOnly.Parse("2025-12-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 377, ReceivingId = 71, ProductId = 224, Quantity = 6, CBM = "0.46", TotalWeight = "36",
                  ExpirationDate = DateOnly.Parse("2025-12-26"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 552,
            },
            new
            {
                  Id = 378, ReceivingId = 72, ProductId = 226, Quantity = 6, CBM = "0.13", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2025-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 379, ReceivingId = 72, ProductId = 227, Quantity = 8, CBM = "0.18", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 380, ReceivingId = 72, ProductId = 228, Quantity = 6, CBM = "0.13", TotalWeight = "12",
                  ExpirationDate = DateOnly.Parse("2025-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 381, ReceivingId = 72, ProductId = 230, Quantity = 6, CBM = "0.12", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-12-05"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 382, ReceivingId = 72, ProductId = 231, Quantity = 6, CBM = "0.12", TotalWeight = "24",
                  ExpirationDate = DateOnly.Parse("2025-11-28"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 383, ReceivingId = 72, ProductId = 229, Quantity = 4, CBM = "0.1", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-12-06"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 553,
            },
            new
            {
                  Id = 384, ReceivingId = 73, ProductId = 233, Quantity = 5, CBM = "0.1", TotalWeight = "60",
                  ExpirationDate = DateOnly.Parse("2027-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 385, ReceivingId = 73, ProductId = 234, Quantity = 5, CBM = "0.1", TotalWeight = "60",
                  ExpirationDate = DateOnly.Parse("2026-02-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 386, ReceivingId = 73, ProductId = 235, Quantity = 3, CBM = "0.06", TotalWeight = "48",
                  ExpirationDate = DateOnly.Parse("2026-01-31"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 387, ReceivingId = 73, ProductId = 236, Quantity = 5, CBM = "0.1", TotalWeight = "80",
                  ExpirationDate = DateOnly.Parse("2026-01-31"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 388, ReceivingId = 73, ProductId = 237, Quantity = 6, CBM = "0.12", TotalWeight = "96",
                  ExpirationDate = DateOnly.Parse("2026-02-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 389, ReceivingId = 73, ProductId = 238, Quantity = 3, CBM = "0.06", TotalWeight = "48",
                  ExpirationDate = DateOnly.Parse("2026-02-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 390, ReceivingId = 73, ProductId = 240, Quantity = 5, CBM = "0.1", TotalWeight = "80",
                  ExpirationDate = DateOnly.Parse("2026-01-30"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 391, ReceivingId = 73, ProductId = 242, Quantity = 10, CBM = "0.2", TotalWeight = "160",
                  ExpirationDate = DateOnly.Parse("2026-01-29"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 392, ReceivingId = 73, ProductId = 243, Quantity = 3, CBM = "0.04", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2026-02-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 393, ReceivingId = 73, ProductId = 244, Quantity = 5, CBM = "0.07", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2026-02-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 394, ReceivingId = 73, ProductId = 245, Quantity = 3, CBM = "0.04", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2026-03-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 395, ReceivingId = 73, ProductId = 246, Quantity = 15, CBM = "0.3", TotalWeight = "240",
                  ExpirationDate = DateOnly.Parse("2026-02-17"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 396, ReceivingId = 73, ProductId = 247, Quantity = 5, CBM = "0.07", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2026-02-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 397, ReceivingId = 73, ProductId = 248, Quantity = 3, CBM = "0.04", TotalWeight = "30",
                  ExpirationDate = DateOnly.Parse("2026-02-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 398, ReceivingId = 73, ProductId = 249, Quantity = 5, CBM = "0.07", TotalWeight = "50",
                  ExpirationDate = DateOnly.Parse("2026-02-02"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 399, ReceivingId = 73, ProductId = 250, Quantity = 10, CBM = "0.14", TotalWeight = "140",
                  ExpirationDate = DateOnly.Parse("2026-03-03"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 554,
            },
            new
            {
                  Id = 400, ReceivingId = 74, ProductId = 251, Quantity = 5, CBM = "0.37", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-09-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 401, ReceivingId = 74, ProductId = 252, Quantity = 5, CBM = "0.37", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-09-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 402, ReceivingId = 74, ProductId = 253, Quantity = 5, CBM = "0.37", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-09-11"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 403, ReceivingId = 74, ProductId = 255, Quantity = 1, CBM = "0.04", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-10-31"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 404, ReceivingId = 74, ProductId = 256, Quantity = 1, CBM = "0.04", TotalWeight = "16",
                  ExpirationDate = DateOnly.Parse("2025-11-01"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 405, ReceivingId = 74, ProductId = 260, Quantity = 5, CBM = "0.16", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-11-18"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 406, ReceivingId = 74, ProductId = 259, Quantity = 5, CBM = "0.16", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-12-19"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 407, ReceivingId = 74, ProductId = 258, Quantity = 5, CBM = "0.16", TotalWeight = "40",
                  ExpirationDate = DateOnly.Parse("2025-12-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 408, ReceivingId = 74, ProductId = 257, Quantity = 2, CBM = "0.11", TotalWeight = "20",
                  ExpirationDate = DateOnly.Parse("2025-12-31"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 555,
            },
            new
            {
                  Id = 409, ReceivingId = 75, ProductId = 261, Quantity = 50, CBM = "0.84", TotalWeight = "525",
                  ExpirationDate = DateOnly.Parse("2026-01-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 556,
            },
            new
            {
                  Id = 410, ReceivingId = 75, ProductId = 261, Quantity = 28, CBM = "0.47", TotalWeight = "294",
                  ExpirationDate = DateOnly.Parse("2026-01-25"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 557,
            },
            new
            {
                  Id = 411, ReceivingId = 75, ProductId = 262, Quantity = 50, CBM = "0.84", TotalWeight = "525",
                  ExpirationDate = DateOnly.Parse("2026-01-07"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 558,
            },
            new
            {
                  Id = 412, ReceivingId = 75, ProductId = 263, Quantity = 51, CBM = "0.85", TotalWeight = "535.5",
                  ExpirationDate = DateOnly.Parse("2026-01-20"),
                  Remarks = "GOOD CONDITION",
                  ContainerName = string.Empty,
                  PalletId = 559,
            }
      );

      
      modelBuilder.Entity<CheckIn>()
        .HasMany(ci => ci.Bins)
        .WithMany(b => b.CheckIns)
        .UsingEntity<Dictionary<string, object>>(
            "CheckInBin", // Join table name
            j => j.HasOne<Bin>().WithMany().HasForeignKey("BinId"),
            j => j.HasOne<CheckIn>().WithMany().HasForeignKey("CheckInId"));

      modelBuilder.Entity<CheckIn>()
            .HasMany(ci => ci.ReceivedProducts)
            .WithMany(rp => rp.CheckIns)
            .UsingEntity<Dictionary<string, object>>(
                  "CheckInReceivedProduct",
                  j => j.HasOne<ReceivedProduct>().WithMany().HasForeignKey("ReceivedProductId"),
                  j => j.HasOne<CheckIn>().WithMany().HasForeignKey("CheckInId"));
    }
}