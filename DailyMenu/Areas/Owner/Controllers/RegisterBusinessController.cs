using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DailyMenu.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RegisterBusinessController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;


        public RegisterBusinessController(IUnitOfWork unitOfWork, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        
        }

        public IActionResult Index()
        {

            //Create the list of cities and initialize it with the cities in the database
            IEnumerable<SelectListItem> CityList;
            CityList = _unitOfWork.City.GetAll().Select(c => new SelectListItem { Text=c.Name,Value=c.ID.ToString()});

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

            //Create a new empty Menu for the Business

            Menu newEmptyMenu = new Menu();
            newEmptyMenu.Name = business.Name + " - Menu";
            _unitOfWork.Menu.Add(newEmptyMenu);
            _unitOfWork.Save();

            //Mapp the new created Menu to the Business
            business.MenuId = newEmptyMenu.ID;
             business.OwnerId = _userManager.GetUserId(HttpContext.User);
                _unitOfWork.Business.Add(business);
                _unitOfWork.Save();


            return RedirectToAction("Index", "Business");


        }






    }
}
