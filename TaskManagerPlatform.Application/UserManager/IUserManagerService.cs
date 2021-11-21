using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Models.UserManager;

namespace TaskManagerPlatform.Application.UserManager
{
    public interface IUserManagerService
    {
        IList<UserRole> GetUserRoles();
        UserRole GetUserRoleByID(int id);
        void Insert(UserRole role);
        UserRole GetByEmail(string email);
        UserRole GetByName(string name);
        bool PasswordSignIn(string email, string password, bool rememberMe = false);
        void Save();
    }
}
