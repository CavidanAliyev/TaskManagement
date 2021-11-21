using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Enum;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.Domain.Issues
{
    public class Issue : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Status Status { get; set; }
        public IList<User> AssignableUsers { get; set; }
    }
}
