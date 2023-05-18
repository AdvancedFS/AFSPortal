using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFSPortal.Models;
using AFSPortal.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFSPortal.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository projectRepository;

        public ProjectController(IProjectRepository repo)
        {
            projectRepository = repo;
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            //var projects = new List<Project>() { new Project {ProjectID=1, ProjectName="xyz",ProjectKey="zsasddsd",Status="false" }
            //, new Project {ProjectID=2, ProjectName="asd",ProjectKey="wewrdsdsss",Status="true" }};

            return View(projectRepository.GetAllProjects().ToList());
        }

        // GET: Project/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Project());
            else
                return View(projectRepository.GetProjectById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ProjectID,ProjectName,ProjectKey,Status,ValidTill")] Project project)
        {
            //if (ModelState.IsValid)
            if(!string.IsNullOrEmpty(project.ProjectName))
            {
                project.ValidTill = DateTime.Now.AddYears(1);
                if (project.ProjectID == 0)
                    projectRepository.AddProject(project);
                else
                    projectRepository.UpdateProject(project);
                //await projectRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id > 0)
            {
                projectRepository.DeleteProject(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

