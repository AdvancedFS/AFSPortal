using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFSPortal.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFSPortal.Controllers
{
    public class ReportedIssuesController : Controller
    {
        private IIssueRepository issueRepository;

        public ReportedIssuesController(IIssueRepository repo)
        {
            issueRepository = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(issueRepository.GetAllIssues().ToList());
        }
    }
}

