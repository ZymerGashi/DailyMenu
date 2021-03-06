using DailyMenu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<City> City { get; set; }

    
        public DbSet<Category> Category { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<MenuItem> MenuItem { get; set; }

        public DbSet<Business> Business { get; set; }

        public DbSet<DailyMenus> DailyMenu { get; set; }


    }
}
