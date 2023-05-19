using System;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
	public interface ICampaignRepository
	{
        IEnumerable<Campaign> GetAllCampaing();
        Campaign GetCampaingById(int id);
        Campaign AddCampaing(Campaign campaign);
        Campaign UpdateCampaing(Campaign campaign);
    }
}

