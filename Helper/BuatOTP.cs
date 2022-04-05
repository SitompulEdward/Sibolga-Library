using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Helper
{
    public class BuatOTP
    {
        public int OTP()
        {
            Random r = new();

            return r.Next(1000, 9999);
        }
    }
}
