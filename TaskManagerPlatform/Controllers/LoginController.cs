using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Organizations;
using TaskManagerPlatform.Application.UserManager;
using TaskManagerPlatform.Application.Users;
using TaskManagerPlatform.Domain.Enum;
using TaskManagerPlatform.Domain.Models.UserManager;
using TaskManagerPlatform.Domain.Organizations;
using TaskManagerPlatform.Domain.Users;
using TaskManagerPlatform.Models;
using TaskManagerPlatform.Web.Models;

namespace TaskManagerPlatform.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserManagerService _userManagerService;

        public LoginController(ILogger<LoginController> logger,
            IUserService userService,
            IOrganizationService organizationService,
            IUserManagerService userManagerService)
        {
            _logger = logger;
            _userService = userService;
            _organizationService = organizationService;
            _userManagerService = userManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost, Route("SignIn")]
        public IActionResult SignIn(LoginViewModel model)
        {
            var user = _userService.GetByEmail(model.Email);
            if (user != null)
            {
                if (_userManagerService.PasswordSignIn(user.Email, user.Password, model.RememberMe))
                {
                    return RedirectToAction("Index", "Issue");
                }
                else
                {
                    ViewBag.Message = "Password incorrect";
                    return View("SignIn");
                }
            }
            else
            {
                ViewBag.Message = "User not found";
                return View("SignUp");
            }
        }

        [HttpPost, Route("SignUp")]
        public IActionResult SignUp(RegisterViewModel model, Organization organization)
        {
            try
            {
                var user = new User
                {
                    Name = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };

                if (ModelState.IsValid)
                {
                    //add user
                    _userService.Insert(user);

                    var userRole = new UserRole
                    {
                        Name = "Admin",
                        Email = user.Email
                    };

                    _userManagerService.Insert(userRole);

                    //add organization
                    _organizationService.Insert(organization);
                    _organizationService.Save();

                    ViewBag.Message = "Check your email and confirm your account, you must be confirmed before you can log in.";

                    return RedirectToAction("SignIn");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return View("SignUp");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
