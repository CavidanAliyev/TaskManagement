using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.Application.Users
{
    public interface IUserService
    {
        User GetByEmail(string email);
        IList<User> GetUsers();
        User GetUserByID(int id);
        void Insert(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        void Save();
    }
}
