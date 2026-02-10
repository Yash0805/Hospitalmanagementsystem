using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace WebApplication5.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<patients> patients { get; init; }
        public DbSet<doctors> Doctors{ get; init; }
        public DbSet<treatments> Treatments { get; init; }
        public DbSet<appointments> Appointments { get; init; }
        public DbSet<medicines> Medicines { get; init; }
        public DbSet<prescriptions> Prescriptions { get; init; }
        public DbSet<bills> Bills { get; init; }
        
    }
}
