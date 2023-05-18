using System;
using AFSPortal.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
                        report.Status = i++;
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

