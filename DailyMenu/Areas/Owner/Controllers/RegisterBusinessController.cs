using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public ClaimsPrincipal ClaimsType { get; private set; }

        public IActionResult Index()
        {
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


            return RedirectToAction("Index", "RegisterBusiness");


        }






    }
}
