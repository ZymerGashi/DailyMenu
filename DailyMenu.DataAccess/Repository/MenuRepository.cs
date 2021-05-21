using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyMenu.DataAccess.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db):base(db) {

            _db = db;
        
        }



        public void Update(Menu menu)
        {
            var entityFromDb = _db.Menu.FirstOrDefault(m=>m.ID == menu.ID);

            entityFromDb.Name = menu.Name;

  

        }
    }
}
