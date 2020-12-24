using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagmentSystem.Models
{
    public partial class TaskManagmentContext : DbContext
    {
        public TaskManagmentContext()
        {
        }

        public TaskManagmentContext(DbContextOptions<TaskManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksCategories> TasksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TaskManagment;Trusted_Connection=True;");

            }
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A0B9225BBE9");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Tasks__7C6949B17703985F");

                entity.Property(e => e.TaskId).ValueGeneratedNever();

                entity.Property(e => e.CompletedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Importance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
/*
            modelBuilder.Entity<TasksCategories>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__TasksCate__Categ__276EDEB3");

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__TasksCate__TaskI__286302EC");
            });*/
            modelBuilder.Entity<TasksCategories>()
           .HasKey(e => new { e.TaskId, e.CategoryId });

            modelBuilder.Entity<TasksCategories>()
                 .HasOne(bc => bc.Task)
                 .WithMany(b => b.TasksCategories)
                 .HasForeignKey(bc => bc.TaskId);
            modelBuilder.Entity<TasksCategories>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.TasksCategories)
                .HasForeignKey(bc => bc.CategoryId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
