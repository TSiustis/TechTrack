﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechTrack.Persistence.DatabaseContext;

#nullable disable

namespace TechTrack.Persistence.Migrations.Write
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20240426191227_UpdatedSerialNumber")]
    partial class UpdatedSerialNumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("write")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechTrack.Domain.Models.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedToUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToUserId");

                    b.ToTable("Equipments", "write");
                });

            modelBuilder.Entity("TechTrack.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "write");
                });

            modelBuilder.Entity("TechTrack.Domain.Models.Equipment", b =>
                {
                    b.HasOne("TechTrack.Domain.Models.User", "AssignedTo")
                        .WithMany("AssignedEquipments")
                        .HasForeignKey("AssignedToUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("TechTrack.Domain.Models.User", b =>
                {
                    b.Navigation("AssignedEquipments");
                });
#pragma warning restore 612, 618
        }
    }
}
