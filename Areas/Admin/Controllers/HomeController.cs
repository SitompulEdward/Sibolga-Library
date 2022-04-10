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
using Microsoft.EntityFrameworkCore;

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

        public HomeController(EmailService email, IAdminService ad, AppDbContext context)
        {
            _context = context;
            _adService = ad;
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

        public async Task<IActionResult> Update(string id)
        {
            var cari = await _adService.SelectAdminId(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _adService.UpdateAdmin(admin);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AdminView()
        {
            var data = _adService.admins();

            return View(data);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _adService.DeleteAdmin(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var cari = await _adService.SelectAdminId(id);

            if (cari == null)
            {
                return NotFound();
            }

            var data = new DetailAdmin();

            data.admin = await _context.Admin.Where(x => x.Admin_Id == id).ToListAsync();


            return View(data);

        }
    }
}
