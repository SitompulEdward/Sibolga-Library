using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<bool> CreateAdminAsync(Admin data);
        Task<List<Admin>> ShowAllDataAdminAsync();
    }
}
