using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School.Logic
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VaVan\\Desktop\\C#\\Desktop\\Desktop\\NET_Samples\\School\\SchoolDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Course).HasMaxLength(50);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StudentSurname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.AverageRating).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.BirthdayYear).HasMaxLength(4);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
