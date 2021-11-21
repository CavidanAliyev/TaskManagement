using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain;
using TaskManagerPlatform.Domain.Issues;
using TaskManagerPlatform.Domain.Models.UserManager;
using TaskManagerPlatform.Domain.Organizations;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.EntityFrameworkCore
{
    public class TaskManagerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TaskManagerDbContext()
        {

        }

        public TaskManagerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "Server=.\\;Database=TaskManagerPlatform;Trusted_Connection=True;MultipleActiveResultSets=true";
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile("appsettings.json")
            // .Build();
            //var conn = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasColumnName(nameof(User.Name))
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.SurName)
                .HasColumnName(nameof(User.SurName))
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnName(nameof(User.Email))
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName(nameof(User.Password))
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();
            modelBuilder.Entity<Issue>()
                .Property(i => i.Title)
                .HasColumnName(nameof(Issue.Title))
                .HasColumnType("nvarchar")
                .HasMaxLength(220);
            modelBuilder.Entity<Issue>()
                .Property(i => i.Description)
                .HasColumnName(nameof(Issue.Description))
                .HasColumnType("nvarchar")
                .HasMaxLength(2000);
            modelBuilder.Entity<Issue>()
                .Property(i => i.Status)
                .HasColumnName(nameof(Issue.Status))
                .HasColumnType("char")
                .HasMaxLength(3);
            modelBuilder.Entity<Issue>()
                .Property(i => i.Deadline)
                .HasColumnName(nameof(Issue.Deadline));
            modelBuilder.Entity<Organization>()
                .Property(o => o.OrganizationName)
                .HasColumnName(nameof(Organization.OrganizationName))
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();
            modelBuilder.Entity<Organization>()
                .Property(o => o.PhoneNumber)
                .HasColumnName(nameof(Organization.PhoneNumber))
                .HasColumnType("char")
                .HasMaxLength(9);
            modelBuilder.Entity<Organization>()
                .Property(o => o.Password)
                .HasColumnName(nameof(Organization.Password))
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();
            modelBuilder.Entity<Organization>()
                .Property(o => o.Email)
                .HasColumnName(nameof(Organization.Email))
                .HasColumnType("nvarchar")
                .IsRequired(); 
            modelBuilder.Entity<UserRole>()
                .Property(o => o.Name)
                .HasColumnName(nameof(UserRole.Name))
                .HasColumnType("nvarchar")
                .IsRequired(); 
            modelBuilder.Entity<UserRole>()
                .Property(o => o.Email)
                .HasColumnName(nameof(UserRole.Email))
                .HasColumnType("nvarchar")
                .IsRequired();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
