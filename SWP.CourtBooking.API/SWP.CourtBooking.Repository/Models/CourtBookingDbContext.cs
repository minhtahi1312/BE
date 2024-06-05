using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP.CourtBooking.Repository.Models;

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

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =localhost; database = CourtBookingDB;uid=sa;pwd=12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__35ABFDE0520DB3AD");

            entity.ToTable("Booking");

            entity.HasIndex(e => e.Code, "UQ__Booking__A25C5AA7912E9A58").IsUnique();

            entity.Property(e => e.BookingId)
                .HasMaxLength(30)
                .HasColumnName("Booking_ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CourtClusterId)
                .HasMaxLength(30)
                .HasColumnName("CourtCluster_ID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.FromTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.ToTime).HasColumnType("datetime");

            entity.HasOne(d => d.CourtCluster).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourtClusterId)
                .HasConstraintName("FK__Booking__CourtCl__52593CB8");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Booking__Custome__5165187F");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__BookingD__83B40D2B10E4C834");

            entity.ToTable("BookingDetail");

            entity.Property(e => e.BookingDetailId)
                .HasMaxLength(30)
                .HasColumnName("BookingDetail_ID");
            entity.Property(e => e.BookingId)
                .HasMaxLength(30)
                .HasColumnName("Booking_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SlotId).HasColumnName("Slot_ID");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__BookingDe__Booki__5535A963");

            entity.HasOne(d => d.Slot).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Slot___5629CD9C");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Court__6EF99EFEB2B12972");

            entity.ToTable("Court");

            entity.Property(e => e.CourtId)
                .HasMaxLength(30)
                .HasColumnName("Court_ID");
            entity.Property(e => e.CourtClusterId)
                .HasMaxLength(30)
                .HasColumnName("CourtCluster_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.CourtCluster).WithMany(p => p.Courts)
                .HasForeignKey(d => d.CourtClusterId)
                .HasConstraintName("FK__Court__CourtClus__3F466844");
        });

        modelBuilder.Entity<CourtCluster>(entity =>
        {
            entity.HasKey(e => e.CourtClusterId).HasName("PK__CourtClu__9485F8609D5CBDEF");

            entity.ToTable("CourtCluster");

            entity.Property(e => e.CourtClusterId)
                .HasMaxLength(30)
                .HasColumnName("CourtCluster_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.CourtClusters)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CourtClus__User___3C69FB99");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB286B970A0E946");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Username, "UQ__Customer__536C85E41710F744").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EA816AE0F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534ADDEC747").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("PK__Deposit__7C0DCE8DC77C034D");

            entity.ToTable("Deposit");

            entity.HasIndex(e => e.VnpayCode, "UQ__Deposit__068FECA576484073").IsUnique();

            entity.Property(e => e.DepositId)
                .HasMaxLength(30)
                .HasColumnName("Deposit_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.VnpayCode)
                .HasMaxLength(50)
                .HasColumnName("VNPayCode");

            entity.HasOne(d => d.Customer).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Deposit__Custome__4D94879B");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slot__1AE2AAAE2D27F6B0");

            entity.ToTable("Slot");

            entity.Property(e => e.SlotId)
                .ValueGeneratedNever()
                .HasColumnName("Slot_ID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(30)
                .HasColumnName("Court_ID");

            entity.HasOne(d => d.Court).WithMany(p => p.Slots)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK__Slot__Court_ID__4222D4EF");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9A8D5625DA220714");

            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(30)
                .HasColumnName("Transaction_ID");
            entity.Property(e => e.BookingId)
                .HasMaxLength(30)
                .HasColumnName("Booking_ID");
            entity.Property(e => e.DepositId)
                .HasMaxLength(30)
                .HasColumnName("Deposit_ID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WalletId)
                .HasMaxLength(30)
                .HasColumnName("Wallet_ID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Transacti__Booki__59063A47");

            entity.HasOne(d => d.Deposit).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.DepositId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Depos__5AEE82B9");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Walle__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D91908CB2D015");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4EBBF40CF").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__User__5C7E359E722A7963").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534AA21FE60").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("User_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__ED453B3BEE76FBF0");

            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .HasMaxLength(30)
                .HasColumnName("Wallet_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .HasColumnName("Customer_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Wallet__Customer__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
