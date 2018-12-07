using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PCI_Website_2018.Models
{
    public partial class ClientsContext : DbContext
    {
        public ClientsContext()
        {
        }

        public ClientsContext(DbContextOptions<ClientsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientList> ClientList { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer(@"PalmerNetDatabase");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "MarketMaker");

            modelBuilder.Entity<ClientList>(entity =>
            {
                entity.HasKey(e => e.CrfPrimaryId);

                entity.HasIndex(e => new { e.CrfCompany, e.CrfPrimaryId })
                    .HasName("CRF_CompanyKey");

                entity.Property(e => e.CrfPrimaryId).HasColumnName("CRF_PrimaryID");

                entity.Property(e => e.CrfCompany)
                    .HasColumnName("CRF_Company")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
