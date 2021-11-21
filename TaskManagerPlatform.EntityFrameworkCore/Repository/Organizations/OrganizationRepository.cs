using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain;
using TaskManagerPlatform.Domain.Organizations;
using TaskManagerPlatform.Domain.Repository;
using TaskManagerPlatform.Domain.Repository.Abstract;

namespace TaskManagerPlatform.EntityFrameworkCore.Repository.Organizations
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        private bool disposed = false;

        public OrganizationRepository(TaskManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var item = _dbContext.Organizations.Find(id);
            _dbContext.Organizations.Remove(item);
        }

        public IEnumerable<Organization> Get()
        {
            return _dbContext.Organizations.ToList();
        }

        public Organization GetByID(int id)
        {
            return _dbContext.Organizations.Find(id);
        }

        public void Insert(Organization entity)
        {
            _dbContext.Organizations.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Organization entity)
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
