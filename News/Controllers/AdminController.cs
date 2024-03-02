using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;

namespace News.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminProfile()
        {
            Admin Ad = _unitOfWork.admin.Get(p => p.Id == DataAccess.Data.CurrentUserId.CurrentId);
            return View(Ad);
        }
        public IActionResult TotalIncident()
        {
            return RedirectToAction("Getpermision", "Incident");
        }
        #region Edit
        public IActionResult Edit(int? id)
        {
            Admin? memberFormdb = _unitOfWork.admin.Get(u => u.Id == id);
            return View(memberFormdb);
        }
        [HttpPost]
        public IActionResult Edit(Admin ob)
        {
            _unitOfWork.admin.Update(ob);
            _unitOfWork.Save();
            TempData["success"] = "information Edit success";
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
