using DailyMenu.Models;
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
        public IActionResult Index()
        {
            return View();
        }

   
    }








}



