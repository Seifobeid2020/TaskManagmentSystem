﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Migrations
{
    [DbContext(typeof(TaskManagmentContext))]
    partial class TaskManagmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagmentSystem.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("CategoryId")
                        .HasName("PK__Categori__19093A0B9225BBE9");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TaskManagmentSystem.Models.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Importance")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.HasKey("TaskId")
                        .HasName("PK__Tasks__7C6949B17703985F");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagmentSystem.Models.TasksCategories", b =>
                {
                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaskId");

                    b.ToTable("TasksCategories");
                });

            modelBuilder.Entity("TaskManagmentSystem.Models.TasksCategories", b =>
                {
                    b.HasOne("TaskManagmentSystem.Models.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__TasksCate__Categ__276EDEB3");

                    b.HasOne("TaskManagmentSystem.Models.Tasks", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK__TasksCate__TaskI__286302EC");
                });
#pragma warning restore 612, 618
        }
    }
}
