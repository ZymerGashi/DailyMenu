using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyMenu.DataAccess.Repository
{
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {

        private readonly ApplicationDbContext _db;

        public BusinessRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        
        }

        public void Update(Business business)
        {
            var businessObjectFromDb = _db.Business.FirstOrDefault(b => b.ID == business.ID);
            if (businessObjectFromDb != null)
            {
                businessObjectFromDb.Name = business.Name;
                businessObjectFromDb.CategoryId = business.CategoryId;
                businessObjectFromDb.CityId = business.CityId;
                businessObjectFromDb.OwnerId = business.OwnerId;
                businessObjectFromDb.MapPositionCoordinates = business.MapPositionCoordinates;
                businessObjectFromDb.MenuId = business.MenuId;
                businessObjectFromDb.IsDeleted = business.IsDeleted;
            }

        }
    }
}
