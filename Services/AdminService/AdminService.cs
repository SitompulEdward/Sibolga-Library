using Sibolga_Library.Models;
using Sibolga_Library.Repositories.AdminRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _AdminRepo;
        public AdminService(IAdminRepository ar)
        {
            _AdminRepo = ar;
        }

        public bool CreateAdmin(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}
