using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS.Areas.Identity.Data;

namespace WMS.Models
{
    public class WMSContext : IdentityDbContext<WMSUser>
    {
        public WMSContext(DbContextOptions<WMSContext> options)
            : base(options)
        {
        }

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StorageSpace> StorageSpaces { get; set; }
        public DbSet<ItemDetails> ItemDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCount> ItemCounts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ImportRequest> ImportRequests { get; set; }
        public DbSet<ExportRequest> ExportRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Item>()
                .HasOne(i => i.StorageSpace)
                .WithMany(sp => sp.Items)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Request>()
                .HasMany(r => r.Items)
                .WithOne(ic => ic.Request)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
