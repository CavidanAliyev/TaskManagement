using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Issues;
using TaskManagerPlatform.Models;

namespace TaskManagerPlatform.Controllers
{
    public class IssueController : Controller
    {
        private readonly ILogger<IssueController> _logger;
        private readonly IIssueService _issueService;

        public IssueController(ILogger<IssueController> logger, IIssueService issueService)
        {
            _logger = logger;
            _issueService = issueService;
        }

        public IActionResult Index()
        {
            return View();
        }  
        
        public IActionResult Create()
        {
            return View();
        }  

        [HttpPost]
        public IActionResult Create(IssueController issue)
        {
            return View();
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
