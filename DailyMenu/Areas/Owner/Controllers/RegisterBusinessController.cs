using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMenu.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RegisterBusinessController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly ApplicationDbContext _db;

        public DbSet<Business> dbSet;

        public RegisterBusinessController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;

            dbSet = db.Set<Business>();
        
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Post(Business business)
        {
                _unitOfWork.Business.Add(business);
                _unitOfWork.Save();


            return RedirectToAction("Index", "RegisterBusiness");


        }


    }
}
