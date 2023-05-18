using System;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
	public interface IIssueRepository
	{
        IEnumerable<Reports> GetAllIssues();
    }
}

