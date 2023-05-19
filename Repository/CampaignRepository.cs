using System;
using System.Data;
using System.Data.SqlClient;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
    public class CampaignRepository : ICampaignRepository
    {

        public IConfiguration Configuration { get; }
        public string connectionString;

        public CampaignRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }

        public IEnumerable<Campaign> GetAllCampaing()
        {
            List<Campaign> campaigns = new List<Campaign>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetFeedbackDetails]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Campaign campaign = new Campaign();
                        campaign.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                        campaign.ProjectName = rdr["ProjectName"].ToString();
                        campaign.CampaignID = Convert.ToInt32(rdr["FeedbackID"].ToString());
                        campaign.Title = rdr["Title"].ToString();
                        campaign.StartFrom = Convert.ToDateTime(rdr["StartFrom"].ToString());
                        campaign.EndOn = Convert.ToDateTime(rdr["EndOn"].ToString());
                        campaign.Status = Convert.ToBoolean(rdr["Status"]);
                        campaigns.Add(campaign);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    campaigns = null;
                }
            }
            return campaigns;
        }

        public Campaign GetCampaingById(int id)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetCampaignById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@FeedBackID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        campaign.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                        campaign.ProjectName = rdr["ProjectName"].ToString();
                        campaign.CampaignID = Convert.ToInt32(rdr["FeedbackID"].ToString());
                        campaign.Title = rdr["Title"].ToString();
                        campaign.StartFrom = Convert.ToDateTime(rdr["StartFrom"].ToString());
                        campaign.EndOn = Convert.ToDateTime(rdr["EndOn"].ToString());
                        campaign.Status = Convert.ToBoolean(rdr["Status"]);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    campaign = null;
                }
            }
            return campaign;
        }

        public Campaign AddCampaing(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public Campaign UpdateCampaing(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}

