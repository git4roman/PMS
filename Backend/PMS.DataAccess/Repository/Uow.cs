using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core;
using PMS.Core.CategoryFeatures;
using PMS.DataAccess.Data;

namespace PMS.DataAccess.Repository
{
    public class Uow : IUow
    {
        private readonly AppDbContext _appDbContext;
        public ICategoryRepo Category { get; private set; }
        public Uow(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Category = new CategoryRepo(_appDbContext);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
