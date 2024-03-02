using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;

namespace News.Controllers
{
    public class JournalistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JournalistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JournalistProfile()
        {
            //index >>incident>>Id
            Journalist jo = _unitOfWork.jornalist.Get(p => p.Id == DataAccess.Data.CurrentUserId.CurrentId);
            return View(jo);
        }
        #region Edit
        public IActionResult Edit(int? id)
        {
            Journalist? memberFormdb = _unitOfWork.jornalist.Get(u => u.Id == id);
            return View(memberFormdb);
        }
        [HttpPost]
        public IActionResult Edit(Journalist ob)
        {
            _unitOfWork.jornalist.Update(ob);
            _unitOfWork.Save();
            TempData["success"] = "information Edit success";
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
