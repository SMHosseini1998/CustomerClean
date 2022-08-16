﻿// <auto-generated />
using System;
using CustomerClean.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerClean.Infrastructure.Migrations
{
    [DbContext(typeof(GeneralContext))]
    [Migration("20220804095850_initt")]
    partial class initt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerClean.Domain.Models.city", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("county_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("province_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("province_id");

                    b.ToTable("city");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.Main_Form_tbl", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gride_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guarantee_Image_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meli_Image_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Services_Id")
                        .HasColumnType("int");

                    b.Property<int>("State_Id")
                        .HasColumnType("int");

                    b.Property<string>("Sys_Id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("City_Id");

                    b.HasIndex("Services_Id");

                    b.ToTable("Main_Form_tbl");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.province", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("province");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.Services_tbl", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Service_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Services_tbl");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.city", b =>
                {
                    b.HasOne("CustomerClean.Domain.Models.province", "Province")
                        .WithMany("citys")
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.Main_Form_tbl", b =>
                {
                    b.HasOne("CustomerClean.Domain.Models.city", "city")
                        .WithMany()
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerClean.Domain.Models.Services_tbl", "Services_tbl")
                        .WithMany()
                        .HasForeignKey("Services_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Services_tbl");

                    b.Navigation("city");
                });

            modelBuilder.Entity("CustomerClean.Domain.Models.province", b =>
                {
                    b.Navigation("citys");
                });
#pragma warning restore 612, 618
        }
    }
}
