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
    [Migration("20240315055836_SeedStudentTable")]
    partial class SeedStudentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
