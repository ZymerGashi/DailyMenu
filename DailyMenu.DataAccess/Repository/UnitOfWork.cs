using DailyMenu.DataAccess.Data;
using DailyMenu.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            //category = new CategoryRepository(_db);

            Business = new BusinessRepository(_db);
            Menu = new MenuRepository(_db);
            City = new CityRepository(_db);
            Category = new CategoryRepository(_db);
        }

        public IBusinessRepository Business { get; private set; }

        public IMenuRepository Menu { get; private set; }

        public ICityRepository City { get; private set; }

        public ICategoryRepository Category { get; private set; }
        //public ICategoryRepository category (get; private set;)


        public void Dispose()
        {
            _db.Dispose();
        }


        public void Save()
        {
            _db.SaveChanges();
        }
        


    }
}
