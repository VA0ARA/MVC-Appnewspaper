using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;
using System.Diagnostics;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        #region SQL-Image
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
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
            Incident incident = _unitOfWork.incident.Get(u => u.Id == id);

            return View(incident);
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