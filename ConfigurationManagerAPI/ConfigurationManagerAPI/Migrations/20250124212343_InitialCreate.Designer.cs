﻿// <auto-generated />
using ConfigurationManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfigurationManagerAPI.Migrations
{
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20250124212343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConfigurationManagerAPI.Models.ConfigurationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationName = "SERVICE-A",
                            IsActive = true,
                            Name = "SiteName",
                            Type = "string",
                            Value = "soty.io"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationName = "SERVICE-B",
                            IsActive = true,
                            Name = "IsBasketEnabled",
                            Type = "bool",
                            Value = "true"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationName = "SERVICE-A",
                            IsActive = false,
                            Name = "MaxItemCount",
                            Type = "int",
                            Value = "50"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
