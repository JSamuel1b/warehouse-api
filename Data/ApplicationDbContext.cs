using Microsoft.EntityFrameworkCore;
using werehouse_api.Entities;
using werehouse_api.Enums;

namespace werehouse_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData([
                new Role() { Id = (int)RoleList.Supervisor, Name = "Supervisor", IsActive = true },
                new Role() { Id = (int)RoleList.Staff, Name = "Staff", IsActive = true },
                new Role() { Id = (int)RoleList.DeptHead, Name = "Dept Head", IsActive = true },
                new Role() { Id = (int)RoleList.ToolCageOperator, Name = "Tool Cage Operator", IsActive = true }
                ]);

            modelBuilder.Entity<Department>().HasData([
                new Department() { Id = 1, Name = "MK", IsActive = true },
                new Department() { Id = 2, Name = "Maintenance", IsActive = true },
                new Department() { Id = 3, Name = "Custodial", IsActive = true }
                ]);

            modelBuilder.Entity<InventoryItem>().HasData([
                new InventoryItem() { Id = 1, Location = "A1-01D-01", SKU = "48678", Name = "Disposable Coverall Medium /Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 2, Location = "A1-01D-02", SKU = "48679", Name = "Disposable Coverall Large /Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 3, Location = "A1-01D-03", SKU = "48680", Name = "Disposable Coverall XL /Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 4, Location = "A1-01D-04A", SKU = "CS485", Name = "Vacuum Bag, For Super Coach Pro 6, GoFree Pro, and ProVac FS6 /Each Pack of 10", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 5, Location = "A1-01D-04B", SKU = "CS420", Name = "Vacuum Bag For Hip Hugger /Each Pack of 10", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 6, Location = "A1-01C-01", SKU = "64789", Name = "Vacuum Bags Lavex /Each Pack of 9", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 7, Location = "A1-01C-02", SKU = "CS425", Name = "Vacuum Bag For Versamatic VS14 /Each Pack of 10", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 8, Location = "A1-01C-02B", SKU = "38784", Name = "Vacuum Bag Sanitaire SC9180, S9100, and C4900 /Each Pack of 5", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 9, Location = "A1-01C-03", SKU = "CS430", Name = "Vacuum Bag, Windsor For Versamatic VSP14 /Each Pack of 10", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 10, Location = "A1-01C-04", SKU = "62713", Name = "Vacuum Bag, ST Sanitaire/ 5/Pack", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 11, Location = "A1-01C-05", SKU = "63393", Name = "Vacuum Bag Lavex 12\" upright/ 9/Pack", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 12, Location = "A1-01C-06", SKU = "64650", Name = "Vacuum Bag Style LS/ 9/Pack", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 13, Location = "A1-01B-01", SKU = "PP435", Name = "Trash Bags Clear, 43\" x 48\" (200/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 14, Location = "A1-01B-02", SKU = "PP415", Name = "Trash Bags Clear, 24\" x 24\" (1000/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 15, Location = "A1-01B-03", SKU = "PP425", Name = "Trash Bags Clear, 33\" x 39\" (250/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 16, Location = "A1-01A-01", SKU = "PP450", Name = "Trash Bags Black, 44\" x 55\" (100/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 17, Location = "A1-01A-02", SKU = "PP455", Name = "Trash Bags Black, 43\" x 47\" (100/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 18, Location = "A1-02C-01", SKU = "FP120", Name = "Trash Bags, Sanitary Napkin Liners, 12\" x 6\" (500/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 19, Location = "A1-02C-02", SKU = "PP335", Name = "Deli Paper 10\" x 10.75\" (500/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 20, Location = "A1-02C-03", SKU = "FP105", Name = "Tampon Procter and Gamble (Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 21, Location = "A1-02C-04", SKU = "FP115", Name = "Maxi Pad Gards, Hospitality Specialty Co. (Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 22, Location = "A1-02B-01", SKU = "PP460", Name = "Trash Bags Black, 49\" x 53\" (75/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 23, Location = "A1-02B-02", SKU = "60707", Name = "Trash Bags Black 58\" x 38\" (100 Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 24, Location = "A1-02A-01", SKU = "PP400", Name = "Trash Bags Clear, 27\" x 35\" (500/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 25, Location = "A1-02A-02", SKU = "PP420", Name = "Trash Bags Clear, 24\" x 33\" (1000/Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 26, Location = "A1-03C-01", SKU = "49618", Name = "8 oz Disposable Beverage Cups For Hot or Cold Drinks (Each Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 27, Location = "A1-03C-02", SKU = "PP205", Name = "5 oz Disposable Beverage Cups For Cold Drinks Each Box 5 0z Disposable Beverage Cups For Cold Drinks (Each Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 28, Location = "A1-03C-03", SKU = "PP211", Name = "9 oz Disposable Beverage Cups For Cold Drinks (Each Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 29, Location = "A1-03C-04", SKU = "PP131", Name = "Facial Tissue, Victoria Bay Rectangular Box (Each Tissue Box", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 30, Location = "A1-03B-01", SKU = "63747", Name = "Baby Wipe Huggies, Unscented Tubs", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 31, Location = "A1-03B-02", SKU = "PP101", Name = "Facial Tissue, Kleenex Cardboard Cube (Each", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 32, Location = "A1-03B-03", SKU = "PP328", Name = "Napkin, Luncheon White Paper 12PK/CS Napkin, Luncheon White Paper 12PK/CS Napkin, Luncheon White Paper 12PK/CS", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 33, Location = "A1-03A-01", SKU = "PP320", Name = "WypAll, All-Purpose Wipes, White (Each Pack", Stock = 10, Unit = "Unit" },
                new InventoryItem() { Id = 34, Location = "A1-03A-02", SKU = "PP315", Name = "WypAll, Wipes Kimberly-Clark (Each Box", Stock = 10, Unit = "Unit" }
                ]);
        }
    }
}
