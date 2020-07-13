﻿// <auto-generated />
using System;
using AlgoLogistics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200711134432_ExplicitFK")]
    partial class ExplicitFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.ApplicationConfig", b =>
                {
                    b.Property<int>("ApplicationConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("application_config_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfigName")
                        .HasColumnName("config_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfigValue")
                        .HasColumnName("config_value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationConfigId");

                    b.ToTable("ApplicationConfig");

                    b.HasData(
                        new
                        {
                            ApplicationConfigId = 1,
                            ConfigName = "BaseDeliveryPrice",
                            ConfigValue = "20"
                        });
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("city_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Country = "Ukraine",
                            Name = "Lviv"
                        },
                        new
                        {
                            CityId = 2,
                            Country = "Ukraine",
                            Name = "Uzgorod"
                        },
                        new
                        {
                            CityId = 3,
                            Country = "Ukraine",
                            Name = "Lutsk"
                        },
                        new
                        {
                            CityId = 4,
                            Country = "Ukraine",
                            Name = "Rivne"
                        },
                        new
                        {
                            CityId = 5,
                            Country = "Ukraine",
                            Name = "Ternopil"
                        },
                        new
                        {
                            CityId = 6,
                            Country = "Ukraine",
                            Name = "Ivano-Frankivsk"
                        },
                        new
                        {
                            CityId = 7,
                            Country = "Ukraine",
                            Name = "Chernivtsi"
                        },
                        new
                        {
                            CityId = 8,
                            Country = "Ukraine",
                            Name = "Zhytomyr"
                        },
                        new
                        {
                            CityId = 9,
                            Country = "Ukraine",
                            Name = "Khmelnytskyi"
                        },
                        new
                        {
                            CityId = 10,
                            Country = "Ukraine",
                            Name = "Vinnytsia"
                        });
                });

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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNo")
                        .IsRequired()
                        .HasColumnName("invoice_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnName("last_modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PackageCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.HasIndex("PackageCategoryId");

                    b.HasIndex("ShipmentId");

                    b.HasIndex("TransportId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.PackageCategory", b =>
                {
                    b.Property<int>("PackageCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("package_category_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Height")
                        .HasColumnName("height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnName("length")
                        .HasColumnType("float");

                    b.Property<string>("SizeCategory")
                        .IsRequired()
                        .HasColumnName("size_category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Width")
                        .HasColumnName("width")
                        .HasColumnType("float");

                    b.HasKey("PackageCategoryId");

                    b.ToTable("PackageCategories");

                    b.HasData(
                        new
                        {
                            PackageCategoryId = 1,
                            Height = 0.050000000000000003,
                            Length = 0.20000000000000001,
                            SizeCategory = "ExtraSmall",
                            Width = 0.14999999999999999
                        },
                        new
                        {
                            PackageCategoryId = 2,
                            Height = 0.10000000000000001,
                            Length = 0.29999999999999999,
                            SizeCategory = "Small",
                            Width = 0.20000000000000001
                        },
                        new
                        {
                            PackageCategoryId = 3,
                            Height = 0.20000000000000001,
                            Length = 0.29999999999999999,
                            SizeCategory = "Medium",
                            Width = 0.29999999999999999
                        },
                        new
                        {
                            PackageCategoryId = 4,
                            Height = 0.29999999999999999,
                            Length = 0.40000000000000002,
                            SizeCategory = "Large",
                            Width = 0.29999999999999999
                        },
                        new
                        {
                            PackageCategoryId = 5,
                            Height = 0.29999999999999999,
                            Length = 0.45000000000000001,
                            SizeCategory = "ExtraLarge",
                            Width = 0.29999999999999999
                        });
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("shipment_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnName("last_modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentStatus")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipmentId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Transport", b =>
                {
                    b.Property<int>("TransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transport_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentCity")
                        .IsRequired()
                        .HasColumnName("current_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportModel")
                        .IsRequired()
                        .HasColumnName("transport_model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportNo")
                        .IsRequired()
                        .HasColumnName("transport_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportType")
                        .IsRequired()
                        .HasColumnName("transport_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransportId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Package", b =>
                {
                    b.HasOne("AlgoLogistics.Domain.Entities.PackageCategory", "PackageCategory")
                        .WithMany("Packages")
                        .HasForeignKey("PackageCategoryId");

                    b.HasOne("AlgoLogistics.Domain.Entities.Shipment", "Shipment")
                        .WithMany("Packages")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AlgoLogistics.Domain.Entities.Transport", "Transport")
                        .WithMany("Packages")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.SetNull);

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

                            b1.Property<string>("ReceiverEmail")
                                .IsRequired()
                                .HasColumnName("receiver_email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Sender")
                                .IsRequired()
                                .HasColumnName("sender")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SenderEmail")
                                .IsRequired()
                                .HasColumnName("sender_email")
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

                    b.OwnsOne("AlgoLogistics.Domain.Entities.Money", "DeliveryPrice", b1 =>
                        {
                            b1.Property<int>("PackageId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasColumnName("delivery_price_amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnName("delivery_price_currency")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PackageId");

                            b1.ToTable("Packages");

                            b1.WithOwner()
                                .HasForeignKey("PackageId");
                        });

                    b.OwnsOne("AlgoLogistics.Domain.Entities.Money", "Price", b1 =>
                        {
                            b1.Property<int>("PackageId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasColumnName("price_amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnName("price_currency")
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

                            b1.Property<double>("Width")
                                .HasColumnName("width")
                                .HasColumnType("float");

                            b1.HasKey("PackageId");

                            b1.ToTable("Packages");

                            b1.WithOwner()
                                .HasForeignKey("PackageId");
                        });
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Shipment", b =>
                {
                    b.OwnsOne("AlgoLogistics.Domain.Entities.Route", "Route", b1 =>
                        {
                            b1.Property<int>("ShipmentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("DestinationCity")
                                .IsRequired()
                                .HasColumnName("destination_city")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Distance")
                                .HasColumnName("distance")
                                .HasColumnType("float");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnName("path")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StartCity")
                                .IsRequired()
                                .HasColumnName("start_city")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ShipmentId");

                            b1.ToTable("Shipments");

                            b1.WithOwner()
                                .HasForeignKey("ShipmentId");
                        });
                });

            modelBuilder.Entity("AlgoLogistics.Domain.Entities.Transport", b =>
                {
                    b.OwnsOne("AlgoLogistics.Domain.Entities.PhysicalParameters", "PhysicalParameters", b1 =>
                        {
                            b1.Property<int>("TransportId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Height")
                                .HasColumnName("height")
                                .HasColumnType("float");

                            b1.Property<double>("Length")
                                .HasColumnName("length")
                                .HasColumnType("float");

                            b1.Property<double>("Width")
                                .HasColumnName("width")
                                .HasColumnType("float");

                            b1.HasKey("TransportId");

                            b1.ToTable("Transports");

                            b1.WithOwner()
                                .HasForeignKey("TransportId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
