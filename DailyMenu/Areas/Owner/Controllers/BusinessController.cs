using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMenu.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class BusinessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public BusinessController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var loggedInUserID = _userManager.GetUserId(HttpContext.User);


            IEnumerable<Business> registeredBusinesses = _unitOfWork.Business.GetAll(b => b.OwnerId == loggedInUserID, includeProperties : "City,Category");

            return View(registeredBusinesses);
        }

   
    }








}



