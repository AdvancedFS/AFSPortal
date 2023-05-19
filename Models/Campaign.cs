using System;
namespace AFSPortal.Models
{
	public class Campaign
	{
        public int CampaignID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public bool Status { get; set; }
        public DateTime? StartFrom { get; set; }
        public DateTime? EndOn { get; set; }
    }
}

