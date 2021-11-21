using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Repository;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user;
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetUserByID(int id)
        {
            var result = _userRepository.GetByID(id);
            return result;
        }

        public IList<User> GetUsers()
        {
            var list = _userRepository.Get().ToList();
            return list;
        }

        public void Insert(User user)
        {
            _userRepository.Insert(user);
        }

        public void Save()
        {
            _userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}
