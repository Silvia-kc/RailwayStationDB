using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RailwayStationDB.Data.Models;

public partial class RailwayStationDbContext : DbContext
{
    public RailwayStationDbContext()
    {
    }

    public RailwayStationDbContext(DbContextOptions<RailwayStationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=STUDENT15;Initial Catalog=RailwayStationDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F118C5B5A87");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Train).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Employees__Train__44FF419A");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Routes__80979B4DF18591D7");

            entity.Property(e => e.ArrivalStation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureStation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");

            entity.HasOne(d => d.Train).WithMany(p => p.Routes)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Routes__TrainId__3A81B327");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC607C6E7916B");

            entity.Property(e => e.PassengerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Route).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK__Tickets__RouteId__4222D4EF");

            entity.HasOne(d => d.Traind).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TraindId)
                .HasConstraintName("FK__Tickets__TraindI__412EB0B6");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK__Tracks__7A74F8E03CB02995");

            entity.HasIndex(e => e.TrackNumber, "UQ__Tracks__C773690764FEBF0C").IsUnique();

            entity.Property(e => e.StationName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Train).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Tracks__TrainId__3E52440B");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.TrainId).HasName("PK__Trains__8ED2723A696A4539");

            entity.HasIndex(e => e.TrainNumber, "UQ__Trains__10C2CD2FB3F01E74").IsUnique();

            entity.Property(e => e.TrainNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
