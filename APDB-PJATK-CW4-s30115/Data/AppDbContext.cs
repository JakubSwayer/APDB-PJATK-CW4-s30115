using APDB_PJATK_CW4_s30115.Models;
using Microsoft.EntityFrameworkCore;

namespace APDB_PJATK_CW4_s30115.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PC> PCs => Set<PC>();
    public DbSet<Component> Components => Set<Component>();
    public DbSet<ComponentType> ComponentTypes => Set<ComponentType>();
    public DbSet<ComponentManufacturer> ComponentManufacturers => Set<ComponentManufacturer>();
    public DbSet<PCComponent> PCComponents => Set<PCComponent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PCId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Component>()
            .HasOne(c => c.Manufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Component>()
            .HasOne(c => c.Type)
            .WithMany(t => t.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Restrict);

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "CPU" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "GPU" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "RAM" },
            new ComponentType { Id = 4, Abbreviation = "SSD", Name = "SSD" },
            new ComponentType { Id = 5, Abbreviation = "MB", Name = "MB" }
        );

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer
            {
                Id = 1, Abbreviation = "Intel", FullName = "Intel",
                FoundationDate = new DateTime(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 2, Abbreviation = "AMD", FullName = "AMD",
                FoundationDate = new DateTime(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 3, Abbreviation = "Corsair", FullName = "Corsair",
                FoundationDate = new DateTime(1994, 1, 1)
            },
            new ComponentManufacturer
            {
                Id = 4, Abbreviation = "Samsung", FullName = "Samsung",
                FoundationDate = new DateTime(1969, 1, 13)
            },
            new ComponentManufacturer
            {
                Id = 5, Abbreviation = "ASUS", FullName = "ASUS",
                FoundationDate = new DateTime(1989, 4, 2)
            }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component
            {
                Code = "0000000001", Name = "i7-13700K",
                Description = "i7-13700K",
                ComponentManufacturersId = 1, ComponentTypesId = 1
            },
            new Component
            {
                Code = "0000000002", Name = "RX 7900 XTX",
                Description = "RX 7900 XTX",
                ComponentManufacturersId = 2, ComponentTypesId = 2
            },
            new Component
            {
                Code = "0000000003", Name = "Vengeance DDR5 32GB",
                Description = "Vengeance DDR5 32GB",
                ComponentManufacturersId = 3, ComponentTypesId = 3
            },
            new Component
            {
                Code = "0000000004", Name = "980 Pro 1TB",
                Description = "980 Pro 1TB",
                ComponentManufacturersId = 4, ComponentTypesId = 4
            },
            new Component
            {
                Code = "0000000005", Name = "ROG Strix B650-A",
                Description = "ROG Strix B650-A",
                ComponentManufacturersId = 5, ComponentTypesId = 5
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC
            {
                Id = 1, Name = "PC-Workstation-01", Weight = 10.0, Warranty = 24,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5
            },
            new PC
            {
                Id = 2, Name = "PC-Workstation-02", Weight = 8.5, Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12
            },
            new PC
            {
                Id = 3, Name = "PC-Server-01", Weight = 15.0, Warranty = 36,
                CreatedAt = new DateTime(2026, 3, 1, 10, 15, 0), Stock = 3
            }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "0000000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "0000000002", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "0000000003", Amount = 2 },
            new PCComponent { PCId = 1, ComponentCode = "0000000005", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "0000000001", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "0000000003", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "0000000004", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "0000000002", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "0000000003", Amount = 4 },
            new PCComponent { PCId = 3, ComponentCode = "0000000004", Amount = 2 }
        );
    }
}
