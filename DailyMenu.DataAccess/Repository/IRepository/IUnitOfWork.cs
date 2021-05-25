using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMenu.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
       
//ICategoryRepository Category {get;}

        IBusinessRepository Business { get; }

        IMenuRepository Menu { get; }

        ICityRepository City { get; }
        ICategoryRepository Category { get; }

        public void Save();

    }
}
