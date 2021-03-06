﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCI_Website_2018.Models;

namespace PCIWebsite2018.Migrations
{
    [DbContext(typeof(FirmContext))]
    partial class FirmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("PCI_Website_2018.Models.Firm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("College");

                    b.Property<string>("Degree");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("Img");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Firm");
                });
#pragma warning restore 612, 618
        }
    }
}
