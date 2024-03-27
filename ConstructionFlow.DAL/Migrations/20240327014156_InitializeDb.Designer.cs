﻿// <auto-generated />
using System;
using ConstructionFlow.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConstructionFlow.DAL.Migrations
{
    [DbContext(typeof(ConstructionFlowDbContext))]
    [Migration("20240327014156_InitializeDb")]
    partial class InitializeDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Activity", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<Guid>("ConstructionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DefaultActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActivityId");

                    b.HasIndex("ConstructionId");

                    b.HasIndex("DefaultActivityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Construction", b =>
                {
                    b.Property<Guid>("ConstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConstructionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Construction");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.ConstructionPhoto", b =>
                {
                    b.Property<Guid>("ConstructionPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConstructionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ConstructionPhotoId");

                    b.HasIndex("ConstructionId");

                    b.ToTable("ConstructionPhoto");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerCnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CustomerCpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.DefaultActivity", b =>
                {
                    b.Property<Guid>("DefaultActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DefaultActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DefaultActivityId");

                    b.ToTable("DefaultActivity");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Status", b =>
                {
                    b.Property<Guid>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Activity", b =>
                {
                    b.HasOne("ConstructionFlow.Domain.Model.Construction", "Construction")
                        .WithMany()
                        .HasForeignKey("ConstructionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConstructionFlow.Domain.Model.DefaultActivity", "DefaultActivity")
                        .WithMany()
                        .HasForeignKey("DefaultActivityId");

                    b.HasOne("ConstructionFlow.Domain.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Construction");

                    b.Navigation("DefaultActivity");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.Construction", b =>
                {
                    b.HasOne("ConstructionFlow.Domain.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConstructionFlow.Domain.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConstructionFlow.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConstructionFlow.Domain.Model.ConstructionPhoto", b =>
                {
                    b.HasOne("ConstructionFlow.Domain.Model.Construction", "Construction")
                        .WithMany()
                        .HasForeignKey("ConstructionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Construction");
                });
#pragma warning restore 612, 618
        }
    }
}
