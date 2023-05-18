using System;
using System.Data;
using System.Data.SqlClient;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }

        public Project AddProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spInsertIntoProject]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@ValidTill", project.ValidTill);
                    cmd.Parameters.AddWithValue("@Status", project.Status);
                    // cmd.Parameters.AddWithValue("@ret", ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    project = null;
                }

            }
            return project;
        }

        public void DeleteProject(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spDeleteProject]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProjectID", id);
                    // cmd.Parameters.AddWithValue("@ret", ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetProjectDetails]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Project project = new Project();
                        project.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                        project.ProjectName = rdr["ProjectName"].ToString();
                        project.ProjectKey = rdr["ProjectKey"].ToString();
                        project.Status = Convert.ToBoolean(rdr["Status"]);
                        projects.Add(project);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    projects = null;
                }
            }
            return projects;
        }

        public Project GetProjectById(int id)
        {
            Project project = new Project();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectProjectById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ProjectID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        project.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                        project.ProjectName = rdr["ProjectName"].ToString();
                        project.ProjectKey = rdr["ProjectKey"].ToString();
                        project.Status = Convert.ToBoolean(rdr["Status"]);
                        project.ValidTill = Convert.ToDateTime(rdr["ValidTill"]);
                    }


                    rdr.Close();
                }
                catch (Exception ex)
                { 
                    project = null;
                }
            }
            return project;
        }

        public Project UpdateProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spUpdateProject]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@ValidTill", project.ValidTill);
                    cmd.Parameters.AddWithValue("@Status", project.Status);
                    // cmd.Parameters.AddWithValue("@ret", ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    project = null;
                }

            }
            return project;
        }
    }
}

