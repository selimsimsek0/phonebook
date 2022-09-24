﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.Data.Context;

namespace PhoneBook.Data.Migrations
{
    [DbContext(typeof(PhoneBookDbContext))]
    partial class PhoneBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PhoneBook.Entity.Entity.ContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MailAddress")
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("PhoneBook.Entity.Entity.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Company")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PhoneBook.Entity.Entity.ContactInfo", b =>
                {
                    b.HasOne("PhoneBook.Entity.Entity.Person", "Person")
                        .WithMany("ContactInfos")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("contactinfos_persons_personid_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PhoneBook.Entity.Entity.Person", b =>
                {
                    b.Navigation("ContactInfos");
                });
#pragma warning restore 612, 618
        }
    }
}