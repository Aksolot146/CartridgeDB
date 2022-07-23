using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendCartridges.Models;

namespace BackendCartridges
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cartridge> Cartridges { get; set; }
        public DbSet<CartridgeType> CartridgeTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Status> Statuses { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            //List<CartridgeType> cartridgeType = new List<CartridgeType>() {
            //    new CartridgeType() { Vender = "Canon", Model = "C300", PartNumber = "RJ54003" },
            //    new CartridgeType() { Vender = "HP", Model = "LazerJetL11", PartNumber = "1192RT333" }
            //};

            //List<Department> departments = new List<Department>()
            //{
            //    new Department() { Name = "A1 Module" },
            //    new Department() { Name = "A2 Module" },
            //    new Department() { Name = "B1 Module" },
            //};

            //List<Employee> employees = new List<Employee>()
            //{
            //    new Employee() { LastName = "Johnson", FirstName = "Robert", MiddleName = "Harris", DepartmentId = 1 },
            //    new Employee() { LastName = "Oakwood", FirstName = "Dylan", MiddleName = "Yoseph", DepartmentId = 3 },
            //};

            //List<Mechanic> mechanics = new List<Mechanic>()
            //{
            //    new Mechanic() { LastName = "Hoffman", FirstName = "Isaac", MiddleName = "Thomas" },
            //    new Mechanic() { LastName = "Schroeder", FirstName = "Scholz", MiddleName = "Ferdinand" },
            //    new Mechanic() { LastName = "Polyethan", FirstName = "Ethan", MiddleName = "Michael" }
            //};

            //List<Status> status = new List<Status>() {
            //    new Status() { Name = "In storage" },
            //    new Status() { Name = "Repairing" },
            //    new Status() { Name = "Working" },
            //    new Status() { Name = "Wroted off" }
            //};

            //CartridgeTypes.AddRange(cartridgeType);
            //Departments.AddRange(departments);
            //Employees.AddRange(employees);
            //Mechanics.AddRange(mechanics);
            //Statuses.AddRange(status);

            //SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartridgeType>().HasMany(p => p.Cartridges).WithOne(t => t.Type).HasForeignKey(p => p.TypeId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>().HasMany(p => p.Employees).WithOne(t => t.Department).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().HasMany(p => p.FromEvents).WithOne(t => t.FromDepartment).HasForeignKey(p => p.FromDepartmentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().HasMany(p => p.ToEvents).WithOne(t => t.ToDepartment).HasForeignKey(p => p.ToDepartmentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Mechanic>().HasMany(p => p.Repairs).WithOne(t => t.Mechanic).HasForeignKey(p => p.MechanicId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Repair>().HasOne(p => p.Event).WithOne(t => t.Repair).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>().HasMany(p => p.Events).WithOne(t => t.Employee).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<Status>().HasMany(p => p.Events).WithOne(t => t.Status).HasForeignKey(p => p.StatusId).OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Event>().HasOne(p => p.Repair).WithOne(t => t.Event).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cartridge>().HasMany(p => p.Events).WithOne(t => t.Cartridge).HasForeignKey(p => p.CartridgeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
