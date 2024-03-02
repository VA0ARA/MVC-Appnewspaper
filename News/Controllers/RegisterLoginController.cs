using Microsoft.AspNetCore.Mvc;
using News.DataAccess.IReposetory;
using News.Models;
using News.Models.Enum;
using News.Models.ModelView;
using News.Services;
using System.Runtime.ConstrainedExecution;

namespace News.Controllers
{
    public class RegisterLoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private Verify ver = new Verify();
        public RegisterLoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        #region Login
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginDtos loginDtos)
        {
            List<Journalist> journalistList = _unitOfWork.jornalist.GetAll().ToList();
            List<Admin>AdminList = _unitOfWork.admin.GetAll().ToList();
            var Selectedjornalist=journalistList.FirstOrDefault(p=>p.InsuranceNumber==loginDtos.InsuranceNumber && p.PhoneNumber==loginDtos.PhoneNumber);
             var Selectedadmin = AdminList.FirstOrDefault(p => p.InsuranceNumber == loginDtos.InsuranceNumber && p.PhoneNumber == loginDtos.PhoneNumber);
            if (Selectedjornalist != null)
            {
                DataAccess.Data.CurrentUserId.CurrentId= Selectedjornalist.Id;
                return View("JournalistProfile","Journalist");

            }
            else if(Selectedadmin != null)
            {
                DataAccess.Data.CurrentUserId.CurrentId = Selectedadmin.Id;
                return View("AdminProfile","Admin");
            }
            else
            {
                NotFound();
                TempData["error"] = "can find any one try again";
                return View();
            }
        }
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //Bug validation
        public IActionResult Create(UserMV user)
        {
            #region Validation PersonExsit
            Journalist obj = _unitOfWork.jornalist.Get(u => u.InsuranceNumber == user.InsuranceNumber);
            if (obj != null)
            {
                ModelState.AddModelError("InsuranceNumber", " this Insurance Number is already exist");
            }
            #endregion
            #region validateName
            if (ver.Verifystring(user.FirstName) == true)
            {
                ModelState.AddModelError("FirstName", " please enter String Name");
            }
            if (ver.Verifystring(user.LastName) == true)
            {
                ModelState.AddModelError("LastName", " please enter String Family Name");
            }
            #endregion
            #region validation Phone-insurence Number

            if (ver.VerifyPhoneNumber(user.PhoneNumber) == false)
            {
                ModelState.AddModelError("PhoneNumber", " shit!! Enter Number, your number must start with '09' and 11 digit");
            }
            int temp = (int)user.InsuranceNumber;
            if (ver.VerifyInsuranceNumber(temp) != true)
            {
                ModelState.AddModelError("InsuranceNumber", " shit!! Enter Number, with 10 digit");
            }

            #endregion
           // if (ModelState.IsValid)
           // {
                if (user.Role == Role.Journalist)
                {
                    user.CreateJournalist();
                    _unitOfWork.jornalist.Add(user.journalist);
                    _unitOfWork.Save();
                    TempData["success"] = "information recorded success";
                    return RedirectToAction("Index","Home");

                }
                else if (user.Role == Role.Admin)
                {
                    user.CreateAdmin();
                    _unitOfWork.admin.Add(user.admin);
                    _unitOfWork.Save();
                    TempData["success"] = "information recorded success";
                    return RedirectToAction("Index","Home");

                }
                //add & save
          //  }
           // else
          //  {
               // TempData["error"] = "information recorded failed";
          //  }
            return View();
        }
        #endregion


        #endregion


        //Journalist
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
            return RedirectToAction("Index","Home");
        }

        #endregion
        #region Deleted
        public IActionResult Delete(int? id)
        {
            Journalist? CategoryFormdb = _unitOfWork.jornalist.Get(u => u.Id == id);
            return View(CategoryFormdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Journalist? cat = _unitOfWork.jornalist.Get(u => u.Id == id);
            _unitOfWork.jornalist.Remove(cat);
            _unitOfWork.Save();
            TempData["success"] = "information Deleted success";
            return RedirectToAction("Index","Home");
        }
        #endregion
    }
}
