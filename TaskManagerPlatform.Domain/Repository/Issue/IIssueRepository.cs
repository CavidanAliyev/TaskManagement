using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Issues;
using TaskManagerPlatform.Domain.Repository.Abstract; 

namespace TaskManagerPlatform.Domain.Repository
{
    public interface IIssueRepository : IRepository<Issue>
    {
    }
}
