using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Sibolga_Library.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    No_Telp = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Admin_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pemasok",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    No_Telp = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pemasok", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Pemasok_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    No_Telp = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                    table.ForeignKey(
                        name: "FK_User_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buku",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Judul_Buku = table.Column<string>(type: "text", nullable: true),
                    Pengarang = table.Column<string>(type: "text", nullable: true),
                    Penerbit = table.Column<string>(type: "text", nullable: true),
                    Tahun_Terbit = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Email_Pemasok = table.Column<string>(type: "varchar(767)", nullable: true),
                    Gambar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buku_Pemasok_Email_Pemasok",
                        column: x => x.Email_Pemasok,
                        principalTable: "Pemasok",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detail_Pemasok",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email_Pemasok = table.Column<string>(type: "varchar(767)", nullable: true),
                    Jumlah_Poin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Pemasok", x => x.No);
                    table.ForeignKey(
                        name: "FK_Detail_Pemasok_Pemasok_Email_Pemasok",
                        column: x => x.Email_Pemasok,
                        principalTable: "Pemasok",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Riwayat_Penarikan",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email_Pemasok = table.Column<string>(type: "varchar(767)", nullable: true),
                    Jumlah_Poin = table.Column<int>(type: "int", nullable: false),
                    Tgl_Penarikan = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riwayat_Penarikan", x => x.No);
                    table.ForeignKey(
                        name: "FK_Riwayat_Penarikan_Pemasok_Email_Pemasok",
                        column: x => x.Email_Pemasok,
                        principalTable: "Pemasok",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Peminjaman",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Email_Peminjam = table.Column<string>(type: "varchar(767)", nullable: true),
                    Tgl_Peminjaman = table.Column<DateTime>(type: "datetime", nullable: false),
                    Jatuh_Tempo = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjaman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peminjaman_User_Email_Peminjam",
                        column: x => x.Email_Peminjam,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detail_Peminjaman",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PeminjamanId = table.Column<string>(type: "varchar(767)", nullable: true),
                    BukuId = table.Column<string>(type: "varchar(767)", nullable: true),
                    Jumlah_Buku = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Peminjaman", x => x.No);
                    table.ForeignKey(
                        name: "FK_Detail_Peminjaman_Buku_BukuId",
                        column: x => x.BukuId,
                        principalTable: "Buku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detail_Peminjaman_Peminjaman_PeminjamanId",
                        column: x => x.PeminjamanId,
                        principalTable: "Peminjaman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pembayaran",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PeminjamanId = table.Column<string>(type: "varchar(767)", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Total_Bayar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembayaran", x => x.No);
                    table.ForeignKey(
                        name: "FK_Pembayaran_Peminjaman_PeminjamanId",
                        column: x => x.PeminjamanId,
                        principalTable: "Peminjaman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pengembalian",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Tgl_Pengembalian = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeminjamanId = table.Column<string>(type: "varchar(767)", nullable: true),
                    Denda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pengembalian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pengembalian_Peminjaman_PeminjamanId",
                        column: x => x.PeminjamanId,
                        principalTable: "Peminjaman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_RolesId",
                table: "Admin",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Buku_Email_Pemasok",
                table: "Buku",
                column: "Email_Pemasok");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Pemasok_Email_Pemasok",
                table: "Detail_Pemasok",
                column: "Email_Pemasok");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Peminjaman_BukuId",
                table: "Detail_Peminjaman",
                column: "BukuId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Peminjaman_PeminjamanId",
                table: "Detail_Peminjaman",
                column: "PeminjamanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pemasok_RolesId",
                table: "Pemasok",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pembayaran_PeminjamanId",
                table: "Pembayaran",
                column: "PeminjamanId");

            migrationBuilder.CreateIndex(
                name: "IX_Peminjaman_Email_Peminjam",
                table: "Peminjaman",
                column: "Email_Peminjam");

            migrationBuilder.CreateIndex(
                name: "IX_Pengembalian_PeminjamanId",
                table: "Pengembalian",
                column: "PeminjamanId");

            migrationBuilder.CreateIndex(
                name: "IX_Riwayat_Penarikan_Email_Pemasok",
                table: "Riwayat_Penarikan",
                column: "Email_Pemasok");

            migrationBuilder.CreateIndex(
                name: "IX_User_RolesId",
                table: "User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Detail_Pemasok");

            migrationBuilder.DropTable(
                name: "Detail_Peminjaman");

            migrationBuilder.DropTable(
                name: "Pembayaran");

            migrationBuilder.DropTable(
                name: "Pengembalian");

            migrationBuilder.DropTable(
                name: "Riwayat_Penarikan");

            migrationBuilder.DropTable(
                name: "Buku");

            migrationBuilder.DropTable(
                name: "Peminjaman");

            migrationBuilder.DropTable(
                name: "Pemasok");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
