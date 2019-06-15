using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

namespace WMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Firm> firms;
        public DbSet<Warehouse> warehouses;
        public DbSet<StorageSpace> storageSpaces;
        public DbSet<ItemDetails> itemDetails;
        public DbSet<Item> items;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Firm>().ToTable("Firms").HasAlternateKey(f => f.FirmName);
        }
    }
}
