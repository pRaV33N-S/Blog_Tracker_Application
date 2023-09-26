using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogTrackerWebApi.Models;

public partial class BlogTrackerContext : DbContext
{
    public BlogTrackerContext()
    {
    }

    public BlogTrackerContext(DbContextOptions<BlogTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminInfo> AdminInfos { get; set; }

    public virtual DbSet<BlogInfo> BlogInfos { get; set; }

    public virtual DbSet<EmpInfo> EmpInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=DESKTOP-FDHH6M8;database=BlogTracker;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminInf__3214EC074503F574");

            entity.ToTable("AdminInfo");

            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BlogInfo>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__BlogInfo__54379E309693AEA7");

            entity.ToTable("BlogInfo");

            entity.Property(e => e.BlogUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfCreation).HasColumnType("datetime");
            entity.Property(e => e.EmpEmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmpInfo__3214EC075774C70A");

            entity.ToTable("EmpInfo");

            entity.HasIndex(e => e.EmailId, "UQ__EmpInfo__7ED91ACEEFDCF563").IsUnique();

            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
