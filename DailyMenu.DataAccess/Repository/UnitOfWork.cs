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

        }

        public IBusinessRepository Business { get; private set; }

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
