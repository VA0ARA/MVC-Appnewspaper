using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;
using News.Models.ModelView;
using System.Diagnostics;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        #region SQL-Image
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IncidentFeedBackMV objDetail=new IncidentFeedBackMV();
        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        public IActionResult Index()
        {
           List<Incident> IncidentsShow=new List<Incident>();
            List<Incident> Incidents = _unitOfWork.incident.GetAll().ToList();
            foreach(var item in Incidents)
            {
                if (item.PermitToPublish == true)
                {
                    IncidentsShow.Add(item);
                }
            }
            return View(IncidentsShow);
        }
        public IActionResult Details(int id)
        {
            objDetail.incidentobj = _unitOfWork.incident.Get(u => u.Id == id);
            objDetail.FeedBackobj = _unitOfWork.feedBack.Get(u => u.Id == id);
            #region Feedback init
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFormdb = _unitOfWork.Category.Get(u => u.Id == id);
            if (CategoryFormdb == null)
            {
                return NotFound();
            }
            return View(CategoryFormdb);
            #endregion
            return View(objDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}