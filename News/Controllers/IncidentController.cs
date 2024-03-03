using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace News.Controllers
{
    public class IncidentController : Controller
    {
        #region SQL-Image
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IncidentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        #region Get
        public IActionResult Index()
        {
            List<Incident>IncidentsOfCurrenJournalist = new List<Incident>();
            List<Incident> Incidents = _unitOfWork.incident.GetAll().ToList();
            foreach(var Item in Incidents )
            {
                if (Item.JournalistId == DataAccess.Data.CurrentUserId.CurrentId)
                {
                    IncidentsOfCurrenJournalist.Add(Item);
                }
            }
            return View(IncidentsOfCurrenJournalist);
        }
        //Admin get
        public IActionResult TotalIncident()
        {
            List<Incident> Incidents = _unitOfWork.incident.GetAll().ToList();
            return View(Incidents);
        }

        #endregion
        #region Create
        public IActionResult Create()        {
            IEnumerable<SelectListItem> CategoryList= _unitOfWork.Category.GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
           // ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Incident obj, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string IncidentPath = Path.Combine(wwwRootPath, @"Image\Incident");
                using (var fileStream = new FileStream(Path.Combine(IncidentPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                // obj.ImageUrl = @"\Image\Incident" + fileName;
                obj.ImageUrl =fileName;
            }
            obj.PermitToPublish = false;
            obj.JournalistId = DataAccess.Data.CurrentUserId.CurrentId;
            if (ModelState.IsValid)
            {
                var cat=_unitOfWork.Category.Get(u => u.Id == obj.CategoryId);
                cat.capacity= cat.capacity-1;
                if (cat.capacity == 0)
                {
                    TempData["error"] = "This category is full  Now!!";
                    return View();
                }
                else
                {
                    _unitOfWork.Category.Update(cat);
                    _unitOfWork.Save();
                    _unitOfWork.incident.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Incident create success";
                    return RedirectToAction("Index");
                }

            }
            return View();

        }
        #endregion
        #region Edit
        public IActionResult Edit(int? id, IFormFile? file)
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
            #region join category
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll()
                    .Select(u => new SelectListItem
                   {
                         Text = u.Name,
                         Value = u.Id.ToString()
                    });
            ViewData["CategoryList"] = CategoryList;
            #endregion
            return View(IncidentFormdb);
        }
        [HttpPost]
        public IActionResult Edit(Incident obj, IFormFile? file)
        {

            #region Image
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                //delete
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string IncidentPath = Path.Combine(wwwRootPath, @"Image\Incident");
                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                //upload
                using (var fileStream = new FileStream(Path.Combine(IncidentPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                //update
                obj.ImageUrl = fileName;
            }
            #endregion
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
        #region GetPermision
        public IActionResult Getpermision(int? id) {
            var incidentobj=_unitOfWork.incident.Get(p=>p.Id == id);   
            return View(incidentobj);
        }
        [HttpPost]
        public IActionResult Getpermision(Incident obj)
        {
                _unitOfWork.incident.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "permission Edit success";
            return RedirectToAction("TotalIncident");
        }
        #endregion
    }
}
