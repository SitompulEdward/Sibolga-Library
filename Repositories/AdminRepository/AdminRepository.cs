using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _AdminDB;

        public AdminRepository(AppDbContext a)
        {
            _AdminDB = a;
        }

        public async Task<bool> CreateAdminAsync(Admin data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Admin>> ShowAllDataAdminAsync()
        {
            throw new NotImplementedException();
        }
    }
}
