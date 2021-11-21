using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Issues;
using TaskManagerPlatform.Domain.Repository;

namespace TaskManagerPlatform.EntityFrameworkCore.Repository.Issues
{
    public class IssueRepository : IIssueRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        private bool disposed = false;

        public IssueRepository(TaskManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var item = _dbContext.Issues.Find(id);
            _dbContext.Issues.Remove(item);
        }

        public IEnumerable<Issue> Get()
        {
            return _dbContext.Issues.ToList();
        }

        public Issue GetByID(int id)
        {
            return _dbContext.Issues.Find(id);
        }

        public void Insert(Issue entity)
        {
            _dbContext.Issues.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Issue entity)
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
