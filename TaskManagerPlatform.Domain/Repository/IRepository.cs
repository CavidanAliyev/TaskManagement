using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPlatform.Domain.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : Entity<int>
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();
    }
}
