using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using BeerShop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfwork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpSert(int? id)
        {
            ProductVM productVM = new ProductVM() 
            {
                Product = new Product(),
                StyleList = _unitOfwork.Style.GetAll().Select(i=>new SelectListItem { 
                
                    Text = i.Name,
                    Value = i.Id.ToString()
                })  
            }; 
            if (id==null)
            {
                //Create Product
                return View(productVM);
            }
            // Edit Product
            productVM.Product = _unitOfwork.Product.Get(id.GetValueOrDefault());
            if (productVM.Product == null)
            {
                return NotFound();
            }
            else
            {
                return View(productVM);
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult UpSert(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (product.Id == 0 )
        //        {
        //            _unitOfwork.Product.Add(product);                    
        //        }
        //        else
        //        {
        //            _unitOfwork.Product.Update(product);                    
        //        }
        //        _unitOfwork.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.Product.GetAll(includePoreperties:"Style,ContainerType");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfwork.Product.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfwork.Product.Remove(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
