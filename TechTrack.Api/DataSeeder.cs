using TechTrack.Domain.Enums;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;

namespace TechTrack.Api
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var readDbContext = services.GetRequiredService<ReadDbContext>();
            var writeDbContext = services.GetRequiredService<WriteDbContext>();

            if (readDbContext.Equipments.Any())
            {
                return;
            }

            if (writeDbContext.Equipments.Any())
            {
                return;
            }

            var equipments = new Equipment[]
            {
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Dell Latitude 5420",
                    Type = "Laptop",
                    SerialNumber = "DL5420XX001",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = new Guid("46187ce0-5637-4435-805a-48c59ebface6")
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "HP EliteDesk 800 G5",
                    Type = "Desktop",
                    SerialNumber = "HE800G5XX002",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Apple MacBook Pro 13",
                    Type = "Laptop",
                    SerialNumber = "AMB13XX003",
                    Status = EquipmentStatus.Assigned,
                    AssignmentDate = DateTime.UtcNow.AddDays(-90),
                    ReturnDate = DateTime.UtcNow.AddDays(30),
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Lenovo ThinkPad X1 Carbon",
                    Type = "Laptop",
                    SerialNumber = "LTX1CXX004",
                    Status = EquipmentStatus.Assigned,
                    AssignmentDate = DateTime.UtcNow.AddDays(-60),
                    ReturnDate = DateTime.UtcNow.AddDays(15),
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Samsung 27' LED Monitor",
                    Type = "Monitor",
                    SerialNumber = "S27LEDXX005",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Logitech MK270 Wireless Keyboard and Mouse Combo",
                    Type = "Keyboard/Mouse",
                    SerialNumber = "LMK270XX006",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Cisco RV345 Dual WAN Gigabit VPN Router",
                    Type = "Router",
                    SerialNumber = "CRV345XX007",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = null
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Seagate Backup Plus 5TB External Hard Drive",
                    Type = "External Hard Drive",
                    SerialNumber = "SBP5TBXX008",
                    Status = EquipmentStatus.Available,
                    AssignmentDate = null,
                    ReturnDate = null,
                    AssignedToUserId = null
                },
            };

            await readDbContext.Equipments.AddRangeAsync(equipments);
            await readDbContext.SaveChangesAsync();

            await writeDbContext.Equipments.AddRangeAsync(equipments);
            await writeDbContext.SaveChangesAsync();

            var users = new User[]
            {
        new() {
            Id = new Guid("46187ce0-5637-4435-805a-48c59ebface6"),
            Name = "John Doe",
            Email = "john@example.com",
            Department = "IT"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Jane Smith",
            Email = "jane@example.com",
            Department = "HR"
        }
            };

            await readDbContext.Users.AddRangeAsync(users);
            await readDbContext.SaveChangesAsync();

            await writeDbContext.Users.AddRangeAsync(users);
            await writeDbContext.SaveChangesAsync();
        }
    }
}
