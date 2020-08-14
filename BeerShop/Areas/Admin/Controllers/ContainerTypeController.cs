using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using BeerShop.Utility;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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

            if (id == null)
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
                if (containerType.Id == 0)
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

        //#region Stored Procedures For Container Type  

        //[Area("Admin")]
        //public class ContainerTypeController : Controller
        //{
        //    private readonly IUnitOfWork _unitOfwork;

        //    public ContainerTypeController(IUnitOfWork unitOfWork)
        //    {
        //        _unitOfwork = unitOfWork;
        //    }

        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    public IActionResult UpSert(int? id)
        //    {
        //        ContainerType containerType = new ContainerType();

        //        if (id == null)
        //        {
        //            //Create ContainerType
        //            return View(containerType);
        //        }
        //        // Edit ContainerType
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@Id", id);
        //        containerType = _unitOfwork.SP_Call.OneRecord<ContainerType>(SD.Proc_ContainerType_Get, parameter);
        //        if (containerType == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return View(containerType);
        //        }
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult UpSert(ContainerType containerType)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var parameter = new DynamicParameters();
        //            parameter.Add("@Name", containerType.Name);
        //            parameter.Add("@Size", containerType.Size);
        //            if (containerType.Id == 0)
        //            {
        //                _unitOfwork.SP_Call.Execute(SD.Proc_ContainerType_Create,parameter);
        //            }
        //            else
        //            {
        //                parameter.Add("@Id", containerType.Id);
        //                _unitOfwork.SP_Call.Execute(SD.Proc_ContainerType_Update,parameter);
        //            }
        //            _unitOfwork.Save();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(containerType);
        //    }

        //    #region API CALLS

        //    [HttpGet]
        //    public IActionResult GetAll()
        //    {
        //    var allObj = _unitOfwork.SP_Call.list<ContainerType>(SD.Proc_ContainerType_GetAll,null);
        //        return Json(new { data = allObj });
        //    }

        //    [HttpDelete]
        //    public IActionResult Delete(int id)
        //    {

        //    var parameter = new DynamicParameters();
        //    parameter.Add("@Id", id);
        //        var objFromDb = _unitOfwork.SP_Call.OneRecord<ContainerType>(SD.Proc_ContainerType_Get,parameter);
        //        if (objFromDb == null)
        //        {
        //            return Json(new { success = false, message = "Error While Deleting" });
        //        }
        //        _unitOfwork.SP_Call.Execute(SD.Proc_ContainerType_Delete,parameter);
        //        _unitOfwork.Save();
        //        return Json(new { success = true, message = "Delete Successful" });
        //    }

        //    #endregion

    }
}


