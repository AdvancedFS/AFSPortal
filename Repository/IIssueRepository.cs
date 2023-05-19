using System;
using AFSPortal.Controllers;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
	public interface IIssueRepository
	{
        IEnumerable<Reports> GetAllIssues();
        IEnumerable<PieDataPoints> GetIssuesCount();
        IEnumerable<ChartData> GetAvgRating();
    }
}

