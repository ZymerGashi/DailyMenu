using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository.IRepository
{
    public interface IBusinessRepository : IRepository<Business>
    {



        void Update(Business business);
    }
}
