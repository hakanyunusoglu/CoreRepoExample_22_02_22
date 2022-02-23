﻿// <auto-generated />
using System;
using CoreRepoExample_22_02_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreRepoExample_22_02_22.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220223060429_AddTables")]
    partial class AddTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeacherID")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Course", b =>
                {
                    b.HasOne("CoreRepoExample_22_02_22.Models.Entity.Teacher", "Teacher")
                        .WithOne("Course")
                        .HasForeignKey("CoreRepoExample_22_02_22.Models.Entity.Course", "TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Teacher", b =>
                {
                    b.HasOne("CoreRepoExample_22_02_22.Models.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CoreRepoExample_22_02_22.Models.Entity.Teacher", b =>
                {
                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}