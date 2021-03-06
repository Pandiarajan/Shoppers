﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCatalogue.Repository;

namespace ProductCatalogue.Repository.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20181117110853_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("ProductCatalogue.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Stationary" },
                        new { Id = 2, Name = "Clothes" },
                        new { Id = 3, Name = "Electronics" }
                    );
                });

            modelBuilder.Entity("ProductCatalogue.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, Description = "Imported Parker Pen", Name = "Parker Pen", Quantity = 5, UnitId = 2 },
                        new { Id = 2, CategoryId = 2, Description = "Branded Shirt", Name = "Mens Shirt", Quantity = 12, UnitId = 2 },
                        new { Id = 3, CategoryId = 2, Description = "Brand B Trouser", Name = "Mens Trouser", Quantity = 25, UnitId = 2 },
                        new { Id = 4, CategoryId = 3, Description = "LED TV", Name = "TV", Quantity = 10, UnitId = 2 }
                    );
                });

            modelBuilder.Entity("ProductCatalogue.Domain.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new { Id = 2, Description = "Descrete" },
                        new { Id = 1, Description = "Gram" },
                        new { Id = 3, Description = "MilliLiter" }
                    );
                });

            modelBuilder.Entity("ProductCatalogue.Domain.Product", b =>
                {
                    b.HasOne("ProductCatalogue.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductCatalogue.Domain.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
