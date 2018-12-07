using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PCI_Website_2018.Models
{
    public partial class ClientsReferencesContext : DbContext
    {
        public ClientsReferencesContext()
        {
        }

        public ClientsReferencesContext(DbContextOptions<ClientsReferencesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientReferences> ClientReferences { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer(@"Server=SQL;Database=Palmernet;uid=pciweb321;pwd=web1pci1;
// ");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "MarketMaker");

            modelBuilder.Entity<ClientReferences>(entity =>
            {
                entity.HasKey(e => e.RefPrimaryId);

                entity.HasIndex(e => new { e.RefCompany, e.RefPrimaryId })
                    .HasName("REF_CompanyKey");

                entity.HasIndex(e => new { e.RefOrder, e.RefFullname, e.RefPrimaryId })
                    .HasName("REF_OrderKey");

                entity.Property(e => e.RefPrimaryId).HasColumnName("REF_PrimaryID");

                entity.Property(e => e.RefAddress)
                    .HasColumnName("REF_Address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RefCityStzip)
                    .HasColumnName("REF_CitySTZip")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RefCompany)
                    .HasColumnName("REF_Company")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RefFax)
                    .HasColumnName("REF_Fax")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RefFullname)
                    .HasColumnName("REF_Fullname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefOrder).HasColumnName("REF_Order");

                entity.Property(e => e.RefPhone)
                    .HasColumnName("REF_Phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
