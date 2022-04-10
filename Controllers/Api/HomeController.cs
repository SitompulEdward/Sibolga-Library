using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Models;
using Sibolga_Library.Services.BukuService;
using Sibolga_Library.Services.PemasokService;
using Sibolga_Library.Services.PeminjamanService;
using Sibolga_Library.Services.PengembalianService;
using Sibolga_Library.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IBukuService _bukuService;
        private readonly IPeminjamanService _pemService;
        private readonly IPengembalianService _pengService;
        private readonly IUserService _userService;
        private readonly IPemasokService _pemasokService;
        public HomeController(IBukuService buku, IPeminjamanService peminjaman, IPengembalianService pengembalian, IUserService user,IPemasokService pemasok)
        {
            _pemasokService = pemasok;
            _userService = user;
            _pengService = pengembalian;
            _pemService = peminjaman;
            _bukuService = buku;
        }

        [Route("buku")]
        public IActionResult Index()
        {
            var buku = _bukuService.buku();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", buku);

            return Ok(respon);
        }

        [Route("buku/{id}")]
        public IActionResult Index(string id)
        {
            var buku = _bukuService.Detail(id);

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", buku);

            return Ok(respon);
        }

        [Route("peminjaman")]
        public IActionResult Peminjaman()
        {
            var data = _pemService.peminjaman();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", data);

            return Ok(respon);
        }

        [Route("pengembalian")]
       public IActionResult Pengembalian()
        {
            var data = _pengService.pengembalian();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", data);

            return Ok(respon);
        }

        [Route("user")]
        public IActionResult User()
        {
            var data = _userService.user();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", data);

            return Ok(respon);
        }

        [Route("pemasok")]
        public IActionResult Pemasok()
        {
            var data = _pemasokService.pemasok();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Data", data);

            return Ok(respon);
        }

        private object Respon(string stat, int code, string pesan, object data)
        {
            return new
            {
                status = stat,
                respon_code = code,
                message = pesan,
                data = data
            };
        }
    }
}
