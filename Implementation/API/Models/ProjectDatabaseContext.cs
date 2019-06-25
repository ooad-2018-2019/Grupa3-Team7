using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class ProjectDatabaseContext : DbContext
    {
        public ProjectDatabaseContext()
        {
        }

        public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ItemCounts> ItemCounts { get; set; }
        public virtual DbSet<ItemDetails> ItemDetails { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<StorageSpaces> StorageSpaces { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ooad-team7.database.windows.net,1433;Initial Catalog=ProjectDatabase;Persist Security Info=False;User ID=team7;Password=The7thHokage!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ItemCounts>(entity =>
            {
                entity.HasKey(e => e.Count);

                entity.HasIndex(e => e.ItemUpc);

                entity.HasIndex(e => e.RequestId);

                entity.Property(e => e.ItemUpc).HasColumnName("ItemUPC");

                entity.HasOne(d => d.ItemUpcNavigation)
                    .WithMany(p => p.ItemCounts)
                    .HasForeignKey(d => d.ItemUpc);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ItemCounts)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<ItemDetails>(entity =>
            {
                entity.HasKey(e => e.Upc);

                entity.Property(e => e.Upc)
                    .HasColumnName("UPC")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageUri).HasColumnName("ImageURI");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasIndex(e => e.ItemDetailsUpc);

                entity.HasIndex(e => e.StorageSpaceId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ItemDetailsUpc).HasColumnName("ItemDetailsUPC");

                entity.HasOne(d => d.ItemDetailsUpcNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemDetailsUpc);

                entity.HasOne(d => d.StorageSpace)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.StorageSpaceId);
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasIndex(e => e.FirmId);

                entity.HasIndex(e => e.StorageSpaceId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discriminator).IsRequired();

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.FirmId);

                entity.HasOne(d => d.StorageSpace)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StorageSpaceId);
            });

            modelBuilder.Entity<StorageSpaces>(entity =>
            {
                entity.HasIndex(e => e.FirmId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.StorageSpaces)
                    .HasForeignKey(d => d.FirmId);
            });

            modelBuilder.Entity<Warehouses>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).ValueGeneratedNever();
            });
        }
    }
}
