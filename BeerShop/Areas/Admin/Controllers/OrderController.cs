using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using BeerShop.Models.ViewModels;
using BeerShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitofWork;
        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM()
            {
                OrderHeader = _unitofWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includePoreperties: "ApplicationUser"),
                OrderDetails = _unitofWork.OrderDetails.GetAll(o => o.OrderId == id, includePoreperties: "Product")
            };
            return View(OrderVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetOrderList(string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))
            {
                orderHeaderList = _unitofWork.OrderHeader.GetAll(includePoreperties: "ApplicationUser");
            }
            else
            {
                orderHeaderList = _unitofWork.OrderHeader.GetAll(u=>u.ApplicationUserId==claim.Value, includePoreperties:"ApplicationUser");
            }

            switch (status)
            {
                case "pending":
                    orderHeaderList = orderHeaderList.Where(o => o.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusApproved || o.OrderStatus == SD.StatusInProcess || o.OrderStatus == SD.StatusPending); ;
                    break;
                case "completed":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusShipped);
                    break;
                case "rejected":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusCancelled || o.OrderStatus == SD.StatusRefunded || o.OrderStatus == SD.PaymentStatusRejected); ;
                    break;
                default:
                    break;
            }

            return Json(new { data = orderHeaderList });
        }
        #endregion
    }
}
