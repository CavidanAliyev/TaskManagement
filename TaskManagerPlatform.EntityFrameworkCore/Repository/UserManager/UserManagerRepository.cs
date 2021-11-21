using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Models.UserManager;
using TaskManagerPlatform.Domain.Repository.UserManager;

namespace TaskManagerPlatform.EntityFrameworkCore.Repository.UserManager
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        private bool disposed = false;
        public UserManagerRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> Get()
        {
            var list = _dbContext.UserRoles.ToList();
            return list;
        }

        public UserRole GetByEmail(string email)
        {
            var role = _dbContext.UserRoles.Where(x => x.Email == email).FirstOrDefault();
            return role;
        }

        public UserRole GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserRole GetByName(string name)
        {
            var role = _dbContext.UserRoles.Where(x => x.Name == name).FirstOrDefault();
            return role;
        }

        public void Insert(UserRole entity)
        {
            _dbContext.UserRoles.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
