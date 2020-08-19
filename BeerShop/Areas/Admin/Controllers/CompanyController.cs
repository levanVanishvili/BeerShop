using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BeerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpSert(int? id)
        {
            Company company = new Company();
            
            if (id==null)
            {
                //Create Company
                return View(company);
            }
            // Edit Company
            company = _unitOfwork.Company.Get(id.GetValueOrDefault());
            if (company==null)
            {
                return NotFound();
            }
            else
            {
                return View(company);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0 )
                {
                    _unitOfwork.Company.Add(company);                    
                }
                else
                {
                    _unitOfwork.Company.Update(company);                    
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.Company.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfwork.Company.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfwork.Company.Remove(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
