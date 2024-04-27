﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentDevelopmentPortal.Data;

#nullable disable

namespace StudentDevelopmentPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240315134223_AddFacultyTableToDb")]
    partial class AddFacultyTableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Faculty", b =>
                {
                    b.Property<long>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FacultyId"));

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculty");

                    b.HasData(
                        new
                        {
                            FacultyId = 2024000001L,
                            Contact = 9786546532L,
                            Email = "megnadesai0123@gmail.com",
                            FullName = "Meghna Desai"
                        },
                        new
                        {
                            FacultyId = 2024000002L,
                            Contact = 9909786590L,
                            Email = "hetalbhavsar2024@gmail.com",
                            FullName = "Hetal Bhavsar"
                        },
                        new
                        {
                            FacultyId = 2024000003L,
                            Contact = 9908765622L,
                            Email = "khsitijgupte.msu@gmail.com",
                            FullName = "Khsitij Gupte"
                        });
                });

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Student", b =>
                {
                    b.Property<long>("Prn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Prn"));

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Prn");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Prn = 8021050206L,
                            Contact = 9786546532L,
                            Email = "maheswaripanda20112004@gmail.com",
                            FullName = "Maheswari Panda",
                            Program = "SS BE-III"
                        },
                        new
                        {
                            Prn = 8021077314L,
                            Contact = 9909786590L,
                            Email = "nitixapatel234@gmail.com",
                            FullName = "Nitixa Patel",
                            Program = "SS BE-III"
                        },
                        new
                        {
                            Prn = 8021047427L,
                            Contact = 9908765622L,
                            Email = "jankichauhan05@gmail.com",
                            FullName = "Janki Chauhan",
                            Program = "SS BE-III"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
