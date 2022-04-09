using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using Sibolga_Library.Services;
using Sibolga_Library.Services.AkunService;
using Sibolga_Library.Services.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly EmailService _email;
        private readonly IAdminService _adService;
        private readonly AppDbContext _context;
        private static int _OTP;

        public HomeController(EmailService email, IAdminService admin, AppDbContext context)
        {
            _context = context;
            _adService = admin;
            _email = email;
        }
        public IActionResult Index()
        {
            var dataView = new GabungView();

            dataView.buku = _adService.buku();
            dataView.pemasok = _adService.pemasok();
            dataView.peminjaman = _adService.peminjaman();
            dataView.pengembalian = _adService.pengembalian();

            return View(dataView);
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(Models.Admin data, IFormFile image, int otp)
        {
            if (ModelState.IsValid)
            {
                if (_OTP == otp)
                {
                    _adService.CreateAdmin(data,image);
                    _adService.createAksesLoginAdmin(data);

                    return RedirectToAction("Daftar");
                }
            }

            return View();
        }

        [HttpPost]
        public string KirimEmailOTP(string tujuanEmail)
        {
            var cariEmail = _context.Akses_Login.FirstOrDefault(x => x.Email == tujuanEmail);

            if (cariEmail != null)
            {
                return "Email Tersebut Sudah di Gunakan !!!";
            }

            BuatOTP _bantu = new();
            _OTP = _bantu.OTP();

            string subjek = "Konfirmasi Email untuk Daftar Akun";

            string isiEmail = "<h1> Berikut Kode OTP Anda <i style='color:blue;'>"
                + _OTP.ToString() + "<i/><h1/>";

            bool cek = _email.SendEmail(tujuanEmail, subjek, isiEmail);

            if (cek)
            {
                return "Kode OTP berhasil di kirim ke " + tujuanEmail;
            }

            return "Email " + tujuanEmail + " tidak ditemukan";

        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult AdminView()
        {
            var data = _adService.admins();

            return View(data);
        }
    }
}
