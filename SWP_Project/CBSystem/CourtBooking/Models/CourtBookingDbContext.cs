using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourtBooking.Models;

public partial class CourtBookingDbContext : DbContext
{
    public CourtBookingDbContext()
    {
    }

    public CourtBookingDbContext(DbContextOptions<CourtBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtCluster> CourtClusters { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =MSI; database = CourtBookingDB;uid=sa;pwd=12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__35ABFDE061918C79");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("Booking_ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CourtClusterId).HasColumnName("CourtCluster_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .HasColumnName("User_ID");

            entity.HasOne(d => d.CourtCluster).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourtClusterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__CourtCl__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__User_ID__5CD6CB2B");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__BookingD__83B40D2BA64E9396");

            entity.ToTable("BookingDetail");

            entity.Property(e => e.BookingDetailId)
                .ValueGeneratedNever()
                .HasColumnName("BookingDetail_ID");
            entity.Property(e => e.BookingId).HasColumnName("Booking_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SlotId).HasColumnName("Slot_ID");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Booki__60A75C0F");

            entity.HasOne(d => d.Slot).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Slot___619B8048");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Court__6EF99EFE0A9E66CF");

            entity.ToTable("Court");

            entity.Property(e => e.CourtId)
                .HasMaxLength(1)
                .HasColumnName("Court_ID");
            entity.Property(e => e.CourtClusterId).HasColumnName("CourtCluster_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.CourtCluster).WithMany(p => p.Courts)
                .HasForeignKey(d => d.CourtClusterId)
                .HasConstraintName("FK__Court__CourtClus__5165187F");
        });

        modelBuilder.Entity<CourtCluster>(entity =>
        {
            entity.HasKey(e => e.CourtClusterId).HasName("PK__CourtClu__9485F86037B58715");

            entity.ToTable("CourtCluster");

            entity.Property(e => e.CourtClusterId)
                .ValueGeneratedNever()
                .HasColumnName("CourtCluster_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.CourtClusters)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CourtClus__User___4E88ABD4");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("PK__Deposit__7C0DCE8D547A4E7F");

            entity.ToTable("Deposit");

            entity.Property(e => e.DepositId)
                .ValueGeneratedNever()
                .HasColumnName("Deposit_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .HasColumnName("User_ID");
            entity.Property(e => e.VnpayCode)
                .HasMaxLength(50)
                .HasColumnName("VNPayCode");

            entity.HasOne(d => d.User).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Deposit__User_ID__68487DD7");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slot__1AE2AAAEA76D97A4");

            entity.ToTable("Slot");

            entity.Property(e => e.SlotId)
                .ValueGeneratedNever()
                .HasColumnName("Slot_ID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(1)
                .HasColumnName("Court_ID");

            entity.HasOne(d => d.Court).WithMany(p => p.Slots)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK__Slot__Court_ID__5441852A");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9A8D5625CD3600A7");

            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("Transaction_ID");
            entity.Property(e => e.BookingId).HasColumnName("Booking_ID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Booking).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Transacti__Booki__6B24EA82");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D91900DCDC139");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E48926B691").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D105344E517B4D").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .HasColumnName("User_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__ED453B3B1B257943");

            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .ValueGeneratedNever()
                .HasColumnName("Wallet_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wallet__User_ID__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
