using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PCI_Website_2018.Models
{
    public class UploadContext : DbContext
    {
        public UploadContext (DbContextOptions<UploadContext> options)
            : base(options)
        {
        }

        public DbSet<PCI_Website_2018.Models.Upload> Upload { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Upload>().HasKey(t => t.ID);
            modelBuilder.Entity<Upload>().Property(b => b.CarouselImg).HasColumnName("CarouselImg");
        }
        

    }
}