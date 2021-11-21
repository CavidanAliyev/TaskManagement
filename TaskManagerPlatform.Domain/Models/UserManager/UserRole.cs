using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPlatform.Domain.Models.UserManager
{
    public class UserRole : Entity<int>
    {
        [BindProperty, Required, Compare(nameof(Name))]
        public string Name { get; set; }

        [BindProperty, Required, Compare(nameof(Email))]
        public string Email { get; set; }
    }
}
