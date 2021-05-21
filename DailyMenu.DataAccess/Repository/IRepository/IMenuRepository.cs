using DailyMenu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository.IRepository
{
    public interface IMenuRepository : IRepository<Menu>
    {

        public void Update(Menu menu);

    }
}
