using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace WebApplication5.Data
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<patients> patients { get; init; }
        public DbSet<doctors> Doctors{ get; init; }
        public DbSet<treatments> Treatments { get; init; }
        public DbSet<appointments> Appointments { get; init; }
        public DbSet<medicines> Medicines { get; init; }
        public DbSet<prescriptions> Prescriptions { get; init; }
        public DbSet<bills> Bills { get; init; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server= DESKTOP-5IQ48AG;Database = hospital;Trusted_Connection=True;TrustServerCertificate=True"
                );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
