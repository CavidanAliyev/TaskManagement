using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Repository;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.EntityFrameworkCore.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        private bool disposed = false;

        public UserRepository(TaskManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public User GetByEmail(string email)
        {
            var result = _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            return result;
        }


        public void Delete(int id)
        {
            var item = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(item);
        }

        public IEnumerable<User> Get()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByID(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Insert(User entity)
        {
            _dbContext.Users.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
