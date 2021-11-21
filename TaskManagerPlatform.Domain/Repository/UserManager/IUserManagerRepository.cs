using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Models.UserManager;
using TaskManagerPlatform.Domain.Repository.Abstract;

namespace TaskManagerPlatform.Domain.Repository.UserManager
{
    public interface IUserManagerRepository: IRepository<UserRole>
    {
        UserRole GetByEmail(string email);
        UserRole GetByName(string name);
    }
}
