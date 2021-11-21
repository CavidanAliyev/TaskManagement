using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Issues;

namespace TaskManagerPlatform.Application.Issues
{
    public interface IIssueService
    {
        IList<Issue> GetIssues();
        Issue GetIssueByID(int id);
        void Insert(Issue issue);
        void DeleteIssue(int id);
        void UpdateIssue(Issue issue);
        void Save();
    }
}
