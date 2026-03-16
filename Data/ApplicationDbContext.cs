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
        }
    }
}
