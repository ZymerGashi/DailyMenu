using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyMenu.DataAccess.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {

        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(City city)
        {
            var objFromDB = _db.City.FirstOrDefault(c=>c.ID==city.ID);

            if (objFromDB != null)
            {
                objFromDB.Name = city.Name;
            
            }
        }
    }
}
