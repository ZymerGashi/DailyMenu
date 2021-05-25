using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        public void Update(Category category);


    }
}
