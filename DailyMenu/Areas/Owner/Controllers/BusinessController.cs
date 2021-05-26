using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ViewBag.registeredBusinesses = registeredBusinesses;

            //Create the list of cities and initialize it with the cities in the database
            IEnumerable<SelectListItem> CityList;
            CityList = _unitOfWork.City.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() });

            //Pass it in the ViewBag so it can be used in the view to build the dropdown
            ViewBag.CityList = CityList;


            //Create the list of categories and initialize it with the categories in the database
            IEnumerable<SelectListItem> CategoryList;
            CategoryList = _unitOfWork.Category.GetAll().Select(ca => new SelectListItem { Text = ca.Name, Value = ca.ID.ToString() });

            //Pass it in the ViewBag so it can be used in the view to build the dropdown
            ViewBag.CategoryList = CategoryList;


            return View();
        }


        [HttpPost]


        public IActionResult Post(Business business)
        {

            var loggedInUserID = _userManager.GetUserId(HttpContext.User);
            var bussinesFromDB = _unitOfWork.Business.Get(business.ID);

            if (business.ID != null && bussinesFromDB.OwnerId==loggedInUserID)
            {
                
                _unitOfWork.Business.Update(business);
                _unitOfWork.Save();
            
            }

            return Redirect("Index");
        }


        

   
    }








}



