using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AkunService
{
    public class FileService
    {
        IWebHostEnvironment _file;

        public FileService(IWebHostEnvironment file)
        {
            _file = file;
        }

        public async Task<string> SimpanFile(IFormFile file)
        {
            string namaFolder = "AccountImages";

            if(file == null)
            {
                return string.Empty;
            }

            var savePath = Path.Combine(_file.WebRootPath, namaFolder);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var namaFile = file.FileName;
            var alamatFile = Path.Combine(savePath, namaFile);

            using(var foto = new FileStream(alamatFile, FileMode.Create))
            {
                await file.CopyToAsync(foto);
            }

            return Path.Combine("/" + namaFolder + "/" + namaFile);
        }
    }
}
