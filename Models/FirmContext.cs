using Microsoft.EntityFrameworkCore;

namespace PCI_Website_2018.Models
{
    public class FirmContext : DbContext
    {
        public FirmContext (DbContextOptions<FirmContext> options)
            : base(options)
        {
        }

        public DbSet<PCI_Website_2018.Models.Firm> Firm { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firm>()
                .Property(b => b.FirstName)
                .IsRequired();
        }
        

    }
}