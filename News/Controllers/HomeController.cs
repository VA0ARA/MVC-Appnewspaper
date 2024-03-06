using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;
using News.Models.ModelView;
using News.Services;
using System.Diagnostics;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        #region SQL-Image
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IncidentFeedBackMV objDetail=new IncidentFeedBackMV();
        private FeedBackinit FeedBackinitobj = new FeedBackinit();
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
            //init Curent Feedback
            objDetail.incidentobj = _unitOfWork.incident.Get(u => u.Id == id);
            objDetail.FeedBackobj=_unitOfWork.feedBack.Get(u => u.IncidentId == objDetail.incidentobj.Id);
            if (objDetail.FeedBackobj == null)
            {
                DataAccess.Data.CurrentFeedback.FirstInit();
                DataAccess.Data.CurrentFeedback.CurentFeedbackobj.IncidentId = objDetail.incidentobj.Id;
                objDetail.FeedBackobj = DataAccess.Data.CurrentFeedback.CurentFeedbackobj;
            }
            return View(objDetail);
        }
        [HttpPost]
        public IActionResult Details(IncidentFeedBackMV obj)
        {
            _unitOfWork.feedBack.Add(obj.FeedBackobj);
            _unitOfWork.Save();
            TempData["success"] = "Feed back submit success";
            return RedirectToAction("Index");
        }
        public void likeButtom() {

            FeedBackinitobj.AddLike();
        
        }
        public void DisLikeButtom()
        {
            FeedBackinitobj.AddDislike();
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