﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using yachay.Models;

namespace yachay.Migrations
{
    [DbContext(typeof(YachayContext))]
    partial class YachayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("yachay.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradeId");

                    b.Property<int>("StudentId");

                    b.Property<int>("UnitId");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("yachay.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("Grade1");

                    b.Property<float?>("Grade2");

                    b.Property<float?>("Grade3");

                    b.Property<int?>("StudentId");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("yachay.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("yachay.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Semester")
                        .HasMaxLength(50);

                    b.Property<float>("Weight1");

                    b.Property<float>("Weight2");

                    b.Property<float>("Weight3");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("yachay.Models.Enrollment", b =>
                {
                    b.HasOne("yachay.Models.Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("yachay.Models.Grade", b =>
                {
                    b.HasOne("yachay.Models.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
