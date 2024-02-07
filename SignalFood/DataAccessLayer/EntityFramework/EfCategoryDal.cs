using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalContext context) : base(context)
        {
        }

		public int CategoryCount()
		{
			using var context = new SignalContext();

			return context.Categories.Count();
		}

		public int ActiveCategoryCount()
		{
			using var context = new SignalContext();
			
			return context.Categories.Where(x => x.CategoryStatus == true).Count();
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalContext();

			return context.Categories.Where(x => x.CategoryStatus == false).Count();
		}
	}
}
