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
    public class CampaignController : Controller
    {
        private ICampaignRepository campaignRepository;

        public CampaignController(ICampaignRepository repo)
        {
            campaignRepository = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(campaignRepository.GetAllCampaing());
        }

        // GET: Project/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Campaign());
            else
                return View(campaignRepository.GetCampaingById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ProjectID,ProjectName,CampaignID,Title,Status,StartFrom,EndOn")] Campaign campaign)
        {
            //if (ModelState.IsValid)
            //if (!string.IsNullOrEmpty(campaign.Title))
            //{
            //  //  project.ValidTill = DateTime.Now.AddYears(1);
            //    if (campaign.ProjectID == 0)
            //        campaignRepository.AddCampaing(campaign);
            //    else
            //        campaignRepository.UpdateCampaing(campaign);
            //    //await projectRepository.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(campaign);
        }

    }
}

