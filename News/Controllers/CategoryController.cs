using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        #endregion
        #region Edit
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFormdb = _unitOfWork.Category.Get(u => u.Id == id);
            if (CategoryFormdb == null)
            {
                return NotFound();
            }
            return View(CategoryFormdb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edit success";
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
            Category? CategoryFormdb = _unitOfWork.Category.Get(u => u.Id == id);
            if (CategoryFormdb == null)
            {
                return NotFound();
            }
            return View(CategoryFormdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? cat = _unitOfWork.Category.Get(u => u.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(cat);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted success";
            return RedirectToAction("Index");

        }
        #endregion
    }
}
