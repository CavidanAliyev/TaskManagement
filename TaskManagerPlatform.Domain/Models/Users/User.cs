using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Issues;
using TaskManagerPlatform.Domain.Models.UserManager;

namespace TaskManagerPlatform.Domain.Users
{
    public class User : Entity<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Issue> AssignedIssues { get; set; } 
    }
}
