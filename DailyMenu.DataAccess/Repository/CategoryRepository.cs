using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository.IRepository;
using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyMenu.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        
        }


        public void Update(Category category)
        {
            var objFromDB = _db.Category.FirstOrDefault(ca => ca.ID==category.ID);

            if (objFromDB != null)
            {
                objFromDB.Name = category.Name;
            
            }
        
        
        }
    }
}
