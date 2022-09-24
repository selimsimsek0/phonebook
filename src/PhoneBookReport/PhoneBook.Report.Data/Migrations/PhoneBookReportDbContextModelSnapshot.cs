﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.Report.Data.Context;

namespace PhoneBook.Report.Data.Migrations
{
    [DbContext(typeof(PhoneBookReportDbContext))]
    partial class PhoneBookReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PhoneBook.Report.Entity.Entity.LocationReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("PersonCount")
                        .HasColumnType("double precision");

                    b.Property<double>("PhoneNumberCount")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("LocationReports");
                });

            modelBuilder.Entity("PhoneBook.Report.Entity.Entity.LocationReportRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DocumentName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DocumentPath")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("LocationReportRequests");
                });

            modelBuilder.Entity("PhoneBook.Report.Entity.Entity.LocationReportRequest", b =>
                {
                    b.HasOne("PhoneBook.Report.Entity.Entity.LocationReport", null)
                        .WithOne("ReportRequest")
                        .HasForeignKey("PhoneBook.Report.Entity.Entity.LocationReportRequest", "ReportId")
                        .HasConstraintName("locationreportrequest_locationreport_reportid_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneBook.Report.Entity.Entity.LocationReport", b =>
                {
                    b.Navigation("ReportRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
