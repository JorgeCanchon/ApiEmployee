using Microsoft.EntityFrameworkCore;
using System;
using ApiEmployee.DataContrats;

namespace ApiEmployee.DataAccess
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<EmployeeViewModel> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (modelBuilder != null)
            {
                modelBuilder.Entity<EmployeeViewModel>(entity =>
                {
                    entity.Property(b => b.FHcreated)
                    .HasDefaultValueSql("now()");
                });

                modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                   .HasAnnotation("Npgsql:ValueGenerationStrategy",
                    Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
            }
        }
    }
}
