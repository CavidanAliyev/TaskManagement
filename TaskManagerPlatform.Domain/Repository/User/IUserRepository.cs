using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Repository.Abstract;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email); 
    }
}
