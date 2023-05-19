using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFSPortal.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFSPortal.Controllers
{
    public class DashboardController : Controller
    {
        private IIssueRepository issueRepository;
        public DashboardController(IIssueRepository repo)
        {
            issueRepository = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            


            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x = "2000", y1 = 2 },
            //    new ChartData { x = "cdc", y1 = 4 },
            //    new ChartData { x = "2002scscs", y1 = 5 },
            //    new ChartData { x = "2003scss", y1 = 5 },
            //    new ChartData { x = "2004", y1 = 6 },
            //    new ChartData { x = "2005scsc", y1 = 8 },
            //};


            //List<PieDataPoints> pieChartPoints = new List<PieDataPoints>
            //{
            //    new PieDataPoints { ExpenseCategory = "Internet Explorer", ExpensePercentage = 6.12, legendName = "Internet <br> Explorer", DataLabelMappingName = "6.12%" },
            //    new PieDataPoints { ExpenseCategory = "Chrome", ExpensePercentage = 57.28, legendName = "Chrome", DataLabelMappingName = "57.28%" },
            //    new PieDataPoints { ExpenseCategory = "Safari", ExpensePercentage = 4.73, legendName = "Safari", DataLabelMappingName = "4.73%" },
            //    new PieDataPoints { ExpenseCategory = "QQ", ExpensePercentage = 5.96, legendName = "QQ", DataLabelMappingName = "5.96%" },
            //    new PieDataPoints { ExpenseCategory = "UC Browser", ExpensePercentage = 4.37, legendName = "UC Browser", DataLabelMappingName = "4.37%" },
            //    new PieDataPoints { ExpenseCategory = "Edge", ExpensePercentage = 7.48, legendName = "Edge", DataLabelMappingName = "7.48%" },
            //    new PieDataPoints { ExpenseCategory = "Others", ExpensePercentage = 14.06, legendName = "Others", DataLabelMappingName = "14.06%" }
            //};

            List<RoundedColumnChartData> ChartPoints = new List<RoundedColumnChartData>
            {
                new RoundedColumnChartData { Country = "Sierra Leone", Rate = 100, Literacy_Rate = 48.1, Text = "48.1%" },
                new RoundedColumnChartData { Country = "South Sudan", Rate = 100, Literacy_Rate = 26.8, Text = "26.8%" },
                new RoundedColumnChartData { Country = "Nepal", Rate = 100, Literacy_Rate = 64.7, Text = "64.7%" },
                new RoundedColumnChartData { Country = "Gambia", Rate = 100, Literacy_Rate = 55.5, Text = "55.5%" },
                new RoundedColumnChartData { Country = "Gyana", Rate = 100, Literacy_Rate = 88.5, Text = "88.5%" },
                new RoundedColumnChartData { Country = "Kenya", Rate = 100, Literacy_Rate = 78.0, Text = "78.0%" },
                new RoundedColumnChartData { Country = "Singapore", Rate = 100, Literacy_Rate = 96.8, Text = "96.8%" },
                new RoundedColumnChartData { Country = "Niger", Rate = 100, Literacy_Rate = 19.1, Text = "19.1%" },
            };

            List<PieDataPoints> pieChartPoints = new List<PieDataPoints>();
            pieChartPoints = issueRepository.GetIssuesCount().ToList();

            List<ChartData> chartData = new List<ChartData>();
            chartData = issueRepository.GetAvgRating().ToList();


            CombinedViewModel model = new CombinedViewModel
            {
                Model1 = pieChartPoints,
                Model2 = chartData,
                Model3 = ChartPoints,
            };

            // ViewBag.TotalProject = chartData.Count;
            ViewBag.TotalProject = pieChartPoints.Sum(data => data.ExpensePercentage);
            ViewBag.AvgRating = (chartData.Sum(data => data.y1) / chartData.Count).ToString() + "/10";
            ViewBag.model = model;

            return View();
        }
    }
    public class PieDataPoints
    {
        public string ExpenseCategory;
        public double ExpensePercentage;
        public string legendName;
        public string DataLabelMappingName;
    }


    public class CombinedViewModel
    {
        public List<PieDataPoints> Model1 { get; set; }
        public List<ChartData> Model2 { get; set; }
        public List<RoundedColumnChartData> Model3 { get; set; }
    }

    public class ChartData
    {
        public string x;
        public double y1;
    }

    public class RoundedColumnChartData
    {
        public string Country;
        public double Rate;
        public double Literacy_Rate;
        public string Text;
    }
}

