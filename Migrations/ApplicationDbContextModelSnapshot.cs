﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMasterDetail.Data;

#nullable disable

namespace TestMasterDetail.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestMasterDetail.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Pet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pet 01",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pet 02",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pet 03",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pet 04",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pet 05",
                            StudentId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pet 06",
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("TestMasterDetail.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("School");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "School 01"
                        },
                        new
                        {
                            Id = 2,
                            Name = "School 02"
                        });
                });

            modelBuilder.Entity("TestMasterDetail.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Student 01",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Student 02",
                            SchoolId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Student 03",
                            SchoolId = 2
                        });
                });

            modelBuilder.Entity("TestMasterDetail.Models.Pet", b =>
                {
                    b.HasOne("TestMasterDetail.Models.Student", "Student")
                        .WithMany("Pet")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TestMasterDetail.Models.Student", b =>
                {
                    b.HasOne("TestMasterDetail.Models.School", "School")
                        .WithMany("Student")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("TestMasterDetail.Models.School", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("TestMasterDetail.Models.Student", b =>
                {
                    b.Navigation("Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
