using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApi_OneToOneApiDemo.Models;

namespace WebApi_OneToOneApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                    
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Passport> passports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Passport)
                .WithOne(ppt => ppt.Person)
                .HasForeignKey<Passport>(ppt => ppt.PersonId);
        }

    }
}
