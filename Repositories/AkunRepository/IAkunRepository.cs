using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AkunRepository
{
    public interface IAkunRepository
    {
        Task<bool> GetUserId(GabungModel gabungModel);
        Task<bool> GetPemasokId(GabungModel gabungModel);
        
        Task<bool> BuatUserAysnc(User data);
        Task<bool> BuatPemasokAsync(Pemasok data);
        
        Task<bool> BuatAksesLogin(AksesLogin data);
        Task<Roles> GetRolesPemasok();
        Task<Roles> GetRolesUser();
        
    }
}
