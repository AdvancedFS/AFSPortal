using System;
using AFSPortal.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AFSPortal.Controllers;

namespace AFSPortal.Repository
{
	public class IssueRepository : IIssueRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;

        public IssueRepository(IConfiguration configuration)
		{
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }

        public IEnumerable<ChartData> GetAvgRating()
        {
            List<ChartData> avgRating = new List<ChartData>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetProjectRatingPerc]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        ChartData rating = new ChartData();
                        rating.x = rdr["ProjectName"].ToString();
                        double per = Convert.ToDouble(rdr["Total Percentage"]);
                        int count = Convert.ToInt32(rdr["Count"]);
                        double percentage = per/count; // Replace with your percentage value
                        int convertedValue = (int)Math.Ceiling(percentage / 10);

                        rating.y1 = convertedValue;
                        avgRating.Add(rating);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    avgRating = null;
                }
            }
            return avgRating;
        }

        public IEnumerable<PieDataPoints> GetIssuesCount()
        {
            List<PieDataPoints> issueCount = new List<PieDataPoints>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetProjectRatingPerc]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        PieDataPoints issue = new PieDataPoints();
                        issue.DataLabelMappingName = rdr["Count"].ToString();
                        issue.ExpenseCategory = rdr["ProjectName"].ToString();
                        issue.ExpensePercentage = Convert.ToInt32(rdr["Count"]);
                        issue.legendName = rdr["ProjectName"].ToString();

                        issueCount.Add(issue);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    issueCount = null;
                }
            }
            return issueCount;
        }

        public IEnumerable<Reports> GetAllIssues()
        {
            List<Reports> reports = new List<Reports>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetReportedIssues]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        Reports report = new Reports();
                        report.ProjectName = rdr["ProjectName"].ToString();
                        report.CreatedBy = rdr["CreatorEmail"].ToString();
                        report.UserName = (rdr["CreatedBy"] != null && !string.IsNullOrEmpty(rdr["CreatedBy"].ToString())) ? rdr["CreatedBy"].ToString() : "Unknown";

                        report.Status = i;
                        report.Description = rdr["Description"].ToString();
                        report.Summary = rdr["Summary"].ToString();
                        reports.Add(report);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    reports = null;
                }
            }
            return reports;
        }
    }
}

