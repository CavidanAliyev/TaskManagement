using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Users;

namespace TaskManagerPlatform.Domain.Organizations
{
    public class Organization : Entity<int>
    {
        [BindProperty, Required, Compare(nameof(OrganizationName))]
        public string OrganizationName { get; set; }

        [BindProperty, MaxLength(9), Compare(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

        [BindProperty, Required, Compare(nameof(Email))]
        public string Email { get; set; }

        [BindProperty, Required, MinLength(6), Compare(nameof(Password))]
        public string Password { get; set; }
        public IList<User> Users { get; set; }
    }
}
