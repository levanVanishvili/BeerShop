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
    public class ContainerTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public ContainerTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpSert(int? id)
        {
            ContainerType containerType = new ContainerType();
            
            if (id==null)
            {
                //Create ContainerType
                return View(containerType);
            }
            // Edit ContainerType
            containerType = _unitOfwork.ContainerType.Get(id.GetValueOrDefault());
            if (containerType == null)
            {
                return NotFound();
            }
            else
            {
                return View(containerType);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(ContainerType containerType)
        {
            if (ModelState.IsValid)
            {
                if (containerType.Id == 0 )
                {
                    _unitOfwork.ContainerType.Add(containerType);                    
                }
                else
                {
                    _unitOfwork.ContainerType.Update(containerType);                    
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(containerType);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.ContainerType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfwork.ContainerType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfwork.ContainerType.Remove(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
