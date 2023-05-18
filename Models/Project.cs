using System;
namespace AFSPortal.Models
{
	public class Project
	{
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
        public bool Status { get; set; }
        public DateTime? ValidTill { get; set; } 
    }
}

