using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;

namespace News.Controllers
{
    public class IncidentController : Controller
    {
        #region SQL
        private readonly IUnitOfWork _unitOfWork;
        public IncidentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Get
        public IActionResult Index()
        {
            List<Incident> Incidents = _unitOfWork.incident.GetAll().ToList();
            return View(Incidents);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Incident obj)
        {
            obj.PermitToPublish = true;
            obj.NumberOfView = 0;
            if (ModelState.IsValid)
            {
                _unitOfWork.incident.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Incident create success";
                return RedirectToAction("Index");
            }
            return View();

        }
        #endregion
        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Incident? IncidentFormdb = _unitOfWork.incident.Get(u => u.Id == id);
            if (IncidentFormdb == null)
            {
                return NotFound();
            }
            return View(IncidentFormdb);
        }
        [HttpPost]
        public IActionResult Edit(Incident obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.incident.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Incident Edit success";
                return RedirectToAction("Index");
            }
            return View();

        }
        #endregion
        #region delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Incident? IncidentFormdb = _unitOfWork.incident.Get(u => u.Id == id);
            if (IncidentFormdb == null)
            {
                return NotFound();
            }
            return View(IncidentFormdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Incident? cat = _unitOfWork.incident.Get(u => u.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            _unitOfWork.incident.Remove(cat);
            _unitOfWork.Save();
            TempData["success"] = "Incident Deleted success";
            return RedirectToAction("Index");

        }
        #endregion
    }
}
