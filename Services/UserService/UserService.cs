using Sibolga_Library.Models;
using Sibolga_Library.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository user)
        {
            _repo = user;
        }

        public List<User> user()
        {
            return _repo.user();
        }
    }
}
