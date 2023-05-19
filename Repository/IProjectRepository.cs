using System;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
	public interface IProjectRepository
	{
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        void DeleteProject(int? id);
    }
}

