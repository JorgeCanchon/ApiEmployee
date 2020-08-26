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

    }
}
