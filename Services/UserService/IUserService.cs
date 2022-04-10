using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.UserService
{
    public interface IUserService
    {
        List<User> user();
    }
}
