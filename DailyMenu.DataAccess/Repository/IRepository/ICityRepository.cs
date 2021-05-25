using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository.IRepository
{
    public interface ICityRepository:IRepository<City>
    {

        public void Update(City city);

    }
}
