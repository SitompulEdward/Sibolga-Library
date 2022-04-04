using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Pemasok> Pemasok { get; set; }
        public virtual DbSet<Buku> Buku { get; set; }
        public virtual DbSet<Peminjaman> Peminjaman { get; set; }
        public virtual DbSet<Pengembalian> Pengembalian { get; set; }
        public virtual DbSet<Pembayaran> Pembayaran { get; set; }
        public virtual DbSet<Detail_Peminjaman> Detail_Peminjaman { get; set; }
        public virtual DbSet<Detail_Pemasok> Detail_Pemasok { get; set; }
        public virtual DbSet<Riwayat_Penarikan> Riwayat_Penarikan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(new Roles[]
            {
                new Roles
                {
                    Id = "1",
                    Name = "Admin"
                },
                new Roles
                {
                    Id = "2",
                    Name = "Pemasok"
                },
                new Roles
                {
                    Id = "3",
                    Name = "User"
                }
            });
        }
    }
}
