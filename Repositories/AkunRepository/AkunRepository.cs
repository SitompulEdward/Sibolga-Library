using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AkunRepository
{
    public class AkunRepository : IAkunRepository
    {
        private readonly AppDbContext _akunDb;

        public AkunRepository(AppDbContext context)
        {
            _akunDb = context;
        }

        public async Task<bool> GetUserId(GabungModel gabungModel)
        {
            string[] Id = await _akunDb.User.Select(x => x.User_Id).ToArrayAsync();

            BuatPrimary.Primary(gabungModel,Id);

            return true;
        }

        public async Task<bool> BuatUserAysnc(User data)
        {
            _akunDb.Add(data);
            await _akunDb.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetPemasokId(GabungModel gabungModel)
        {
            string[] Id = await _akunDb.Pemasok.Select(x => x.Pemasok_Id).ToArrayAsync();
            BuatPrimary.PrimaryPemasok(gabungModel, Id);

            return true;
        }

        public async Task<bool> GetAdminId(Admin admin)
        {
            string[] Id = await _akunDb.Admin.Select(x => x.Admin_Id).ToArrayAsync();
            BuatPrimary.PrimaryAdmin(admin, Id);

            return true;
        }

        public async Task<bool> BuatPemasokAsync(Pemasok data)
        {
            _akunDb.Add(data);
            await _akunDb.SaveChangesAsync();

            return true;
        }

        public async Task<bool> BuatAksesLogin(AksesLogin data)
        {
            _akunDb.Add(data);
            await _akunDb.SaveChangesAsync();

            return true;
        }

        public async Task<Roles> GetRolesPemasok()
        {   
            return await _akunDb.Roles.Where(x => x.Id == "2").FirstOrDefaultAsync();
        }

        public async Task<Roles> GetRolesUser()
        {
            return await _akunDb.Roles.Where(x => x.Id == "3").FirstOrDefaultAsync();
        }

        public async Task<Roles> GetRolesAdmin()
        {
            return await _akunDb.Roles.Where(x => x.Id == "1").FirstOrDefaultAsync();
        }

        public async Task<bool> BuatAdminAsync(Admin data)
        {
            _akunDb.Add(data);
            await _akunDb.SaveChangesAsync();

            return true;
        }

        
    }
}
