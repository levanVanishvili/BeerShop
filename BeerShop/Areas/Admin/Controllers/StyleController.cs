using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Areas.Admin.Controllers
{

    [Area("Admin")]
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

        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.Style.GetAll();
            return Json(new { data = allObj });
        }


        #endregion
    }
}
