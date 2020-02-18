﻿// <auto-generated />
using System;
using AlgoLogistics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("package_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnName("delivery_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnName("last_modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Package", b =>
                {
                    b.OwnsOne("AlgoLogistics.Domain.Entities.DeliveryDetails", "DeliveryDetails", b1 =>
                        {
                            b1.Property<int>("PackageId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FromCity")
                                .IsRequired()
                                .HasColumnName("from_city")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Receiver")
                                .IsRequired()
                                .HasColumnName("receiver")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Sender")
                                .IsRequired()
                                .HasColumnName("sender")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ToCity")
                                .IsRequired()
                                .HasColumnName("to_city")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PackageId");

                            b1.ToTable("Packages");

                            b1.WithOwner()
                                .HasForeignKey("PackageId");
                        });

                    b.OwnsOne("AlgoLogistics.Domain.Entities.PhysicalParameters", "PhysicalParameters", b1 =>
                        {
                            b1.Property<int>("PackageId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Height")
                                .HasColumnName("height")
                                .HasColumnType("float");

                            b1.Property<double>("Length")
                                .HasColumnName("length")
                                .HasColumnType("float");

                            b1.Property<double>("Weight")
                                .HasColumnName("weight")
                                .HasColumnType("float");

                            b1.Property<double>("Width")
                                .HasColumnName("width")
                                .HasColumnType("float");

                            b1.HasKey("PackageId");

                            b1.ToTable("Packages");

                            b1.WithOwner()
                                .HasForeignKey("PackageId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
