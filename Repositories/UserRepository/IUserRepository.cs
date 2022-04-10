using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.UserRepository
{
    public interface IUserRepository
    {
        List<User> user();
    }
}