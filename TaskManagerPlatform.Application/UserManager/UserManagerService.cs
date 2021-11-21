using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Models.UserManager;
using TaskManagerPlatform.Domain.Repository;
using TaskManagerPlatform.Domain.Repository.UserManager;

namespace TaskManagerPlatform.Application.UserManager
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IUserRepository _userRepository;

        public UserManagerService(IUserManagerRepository userManagerRepository,
            IUserRepository userRepository)
        {
            _userManagerRepository = userManagerRepository;
            _userRepository = userRepository;
        }

        public bool PasswordSignIn(string email, string password, bool rememberMe = false)
        {
            var user = _userRepository.GetByEmail(email);
            if (user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserRole GetByEmail(string email)
        {
            var item = _userManagerRepository.GetByEmail(email);
            return item;
        }

        public UserRole GetByName(string name)
        {
            var item = _userManagerRepository.GetByName(name);
            return item;
        }

        public UserRole GetUserRoleByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UserRole> GetUserRoles()
        {
            var list = _userManagerRepository.Get().ToList();
            return list;
        }

        public void Insert(UserRole role)
        {
            _userManagerRepository.Insert(role);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
