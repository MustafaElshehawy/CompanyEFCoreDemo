using companySD.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace companySD
{
    internal class CompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-83JGNAI ;DataBase=CompanySD3 ; Trusted_connection =true ; TrustServerCertificate  =true");
        }

        //Fluent API ===> to make Rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(em => em.Employee)
                .WithMany(em => em.EmployeeProjects)
                .HasForeignKey(em => em.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(em => em.project)
                .WithMany(em => em.EmployeeProjects)
                .HasForeignKey(em => em.ProjectId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.DepartmentId);



        }

        //Tables

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeesProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
    }


}
