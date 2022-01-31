using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Models;

namespace DbFirst_one_to_many_crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<Department> Departments_jay { get; set; }
        public DbSet<Employee> Employees_jay { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           foreach(var foreignkey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
           /* modelBuilder.Entity<Department>()
    .HasMany(c => c.Employee)
    .WithOne(e => e.Company).OnDelete(DeleteBehavior.SetNull);*/
            //it's process known as fluent model
            modelBuilder.Entity<Department>().HasData(
                new Department {DepartmentId=1, DepartmentName = "SMD", Description = "SMD DEPARTMENT" },
                new Department { DepartmentId =2, DepartmentName = "POC", Description = "POC DEPARTMENT " }
                );
            modelBuilder.Entity<Employee>().HasData(
               new Employee {Id=1, FirstName = "Arya", LastName = "khan", Email = "SMD@gmailcom", Mobile = "7878765656",Description="hi" },
               new Employee { Id = 2, FirstName = "Mayank", LastName = "khanna", Email = "SMD123@gmailcom", Mobile = "7876564556", Description = "hi mayank" }
               );
        }
    }
}
