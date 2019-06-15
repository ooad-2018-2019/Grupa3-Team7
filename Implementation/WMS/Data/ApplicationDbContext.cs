using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StorageSpace> StorageSpaces { get; set; }
        public DbSet<ItemDetails> ItemDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCount> ItemCounts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ImportRequest> ImportRequests { get; set; }
        public DbSet<ExportRequest> ExportRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
