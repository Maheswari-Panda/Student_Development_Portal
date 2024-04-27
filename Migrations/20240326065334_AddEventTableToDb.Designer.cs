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
    [Migration("20240326065334_AddEventTableToDb")]
    partial class AddEventTableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Assignment", b =>
                {
                    b.Property<long>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AssignmentId"));

                    b.Property<string>("AssignedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignedDueDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            AssignmentId = 1L,
                            AssignedDate = "26-03-2024",
                            AssignedDueDate = "02-04-2024",
                            AssignmentName = "DBMS Assignment 1",
                            CourseId = "CSE5501",
                            Description = "Design a relational database schema for an online bookstore.",
                            FacultyId = "2024000001",
                            TotalMarks = 10
                        },
                        new
                        {
                            AssignmentId = 2L,
                            AssignedDate = "26-03-2024",
                            AssignedDueDate = "09-04-2024",
                            AssignmentName = "DSA Assignment 1",
                            CourseId = "CSE6502",
                            Description = "Implement a binary search tree and perform various operations like insertion, deletion, and traversal.",
                            FacultyId = "2024000002",
                            TotalMarks = 10
                        });
                });

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsPractical")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = "CSE5501",
                            CourseDescription = "Computer graphics is about making pictures using computers. It includes 2D and 3D images, animation, interactive graphics, and applications in various fields like entertainment and design. It requires knowledge of computers, programming, and creativity.",
                            CourseName = "Computer Graphics",
                            IsPractical = "Yes",
                            MaterialLink = "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link",
                            Program = "FS BE-III",
                            TotalMarks = 150
                        },
                        new
                        {
                            CourseId = "CSE6502",
                            CourseDescription = "Computer networks involve connecting computers together so they can share information. It includes things like understanding how computers communicate, setting up connections between them, and managing the flow of data. People use computer networks for things like accessing the internet, sharing files, and communicating with each other. ",
                            CourseName = "Computer Networks",
                            IsPractical = "Yes",
                            MaterialLink = "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link",
                            Program = "FS BE-III",
                            TotalMarks = 150
                        },
                        new
                        {
                            CourseId = "CSE5503",
                            CourseDescription = "Theory of Computation (ToC) is about understanding how computers work and what they can do. It involves studying different kinds of problems and figuring out if they can be solved by computers or not. ",
                            CourseName = "Theory Of Computation",
                            IsPractical = "No",
                            MaterialLink = "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link",
                            Program = "FS BE-III",
                            TotalMarks = 150
                        });
                });

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1L,
                            Description = "Description of Event 1",
                            EventDate = "26-03-2024",
                            EventLocation = "Location 1",
                            EventName = "Event 1",
                            FacultyId = 2024000001L
                        },
                        new
                        {
                            EventId = 2L,
                            Description = "Description of Event 2",
                            EventDate = "26-03-2024",
                            EventLocation = "Location 2",
                            EventName = "Event 2",
                            FacultyId = 2024000002L
                        });
                });

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

            modelBuilder.Entity("StudentDevelopmentPortal.Models.JobReadiness", b =>
                {
                    b.Property<string>("QuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("JobRedinessQ");

                    b.HasData(
                        new
                        {
                            QuestionId = "Q1",
                            Answer = "Example answer 1",
                            FacultyId = 2024000001L,
                            Question = "Example question 1",
                            Type = "Type1"
                        },
                        new
                        {
                            QuestionId = "Q2",
                            Answer = "Example answer 2",
                            FacultyId = 2024000002L,
                            Question = "Example question 2",
                            Type = "Type2"
                        });
                });

            modelBuilder.Entity("StudentDevelopmentPortal.Models.Problem", b =>
                {
                    b.Property<string>("ProblemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Hint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inputs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Outputs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpaceComplexity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeComplexity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProblemId");

                    b.ToTable("Problems");

                    b.HasData(
                        new
                        {
                            ProblemId = "P1",
                            CourseId = "CSE5501",
                            Description = "Example problem description 1",
                            FacultyId = 2024000001L,
                            Hint = "Example hint 1",
                            Inputs = "[\"Input 1\",\"Input 2\"]",
                            Level = "Easy",
                            Outputs = "[\"Output 1\",\"Output 2\"]",
                            Solution = "Example solution 1",
                            SpaceComplexity = "O(1)",
                            Statement = "Example problem statement 1",
                            TimeComplexity = "O(n)"
                        },
                        new
                        {
                            ProblemId = "P2",
                            CourseId = "CSE6502",
                            Description = "Example problem description 2",
                            FacultyId = 2024000001L,
                            Hint = "Example hint 2",
                            Inputs = "[\"Input 3\",\"Input 4\"]",
                            Level = "Medium",
                            Outputs = "[\"Output 3\",\"Output 4\"]",
                            Solution = "Example solution 2",
                            SpaceComplexity = "O(n)",
                            Statement = "Example problem statement 2",
                            TimeComplexity = "O(log n)"
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
