using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using theObjects.Database.Helpers;
using theObjects.Database.Model.Data;

namespace theObjects.Database
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Point> Point { get; set; }
        public DbSet<Rectangle> Rectangle { get; set; }
        public DbSet<Square> Square { get; set; }
        public DbSet<Circle> Circle { get; set; }
        public DbSet<Line> Line { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.X).IsRequired();
                entity.Property(e => e.Y).IsRequired();
                entity.Property(e => e.Area).HasDefaultValue(0);
                entity.Property(e => e.Perimeter).HasDefaultValue(0);
            });

            modelBuilder.Entity<Rectangle>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Lenght).IsRequired();
                entity.Property(e => e.Width).IsRequired();
                entity.Property(e => e.Area).HasDefaultValue(0);
                entity.Property(e => e.Perimeter).HasDefaultValue(0);
                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Rectangles);
            });

            modelBuilder.Entity<Square>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Side).IsRequired();
                entity.Property(e => e.Area).HasDefaultValue(0);
                entity.Property(e => e.Perimeter).HasDefaultValue(0);
                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Squares);
            });

            modelBuilder.Entity<Circle>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Diameter).IsRequired();
                entity.Property(e => e.Area).HasDefaultValue(0);
                entity.Property(e => e.Perimeter).HasDefaultValue(0);
                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Circles);
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Area).HasDefaultValue(0);
                entity.Property(e => e.Perimeter).HasDefaultValue(0);
                entity.HasOne(d => d.StartPosition)
                    .WithMany(p => p.StartLines);
                entity.HasOne(d => d.EndPosition)
                    .WithMany(p => p.EndLines);
            });
        }
    }
}
