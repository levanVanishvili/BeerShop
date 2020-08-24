using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using BeerShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BeerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]

    public class StyleController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public StyleController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpSert(int? id)
        {
            Style style = new Style();
            
            if (id==null)
            {
                //Create Style
                return View(style);
            }
            // Edit Style
            style = _unitOfwork.Style.Get(id.GetValueOrDefault());
            if (style==null)
            {
                return NotFound();
            }
            else
            {
                return View(style);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Style style)
        {
            if (ModelState.IsValid)
            {
                if (style.Id == 0 )
                {
                    _unitOfwork.Style.Add(style);                    
                }
                else
                {
                    _unitOfwork.Style.Update(style);                    
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(style);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.Style.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfwork.Style.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfwork.Style.Remove(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
