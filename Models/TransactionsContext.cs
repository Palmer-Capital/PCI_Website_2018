using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Web;

namespace PCI_Website_2018.Models
{
    public partial class TransactionsContext : DbContext
    {
        public TransactionsContext()
        {
        }

        public TransactionsContext(DbContextOptions<TransactionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WebsiteTransactions> WebsiteTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"PalmerNetDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "MarketMaker");

            modelBuilder.Entity<WebsiteTransactions>(entity =>
            {
                entity.HasKey(e => e.WtrPrimaryId);

                entity.Property(e => e.WtrPrimaryId).HasColumnName("WTR_PrimaryID");

                entity.Property(e => e.WtrCity)
                    .HasColumnName("WTR_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WtrDescription)
                    .HasColumnName("WTR_Description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.WtrImage)
                    .HasColumnName("WTR_Image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WtrName)
                    .HasColumnName("WTR_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WtrSize)
                    .HasColumnName("WTR_Size")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WtrSizeNumeric).HasColumnName("WTR_SizeNumeric");

                entity.Property(e => e.WtrState)
                    .HasColumnName("WTR_State")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WtrType)
                    .HasColumnName("WTR_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
