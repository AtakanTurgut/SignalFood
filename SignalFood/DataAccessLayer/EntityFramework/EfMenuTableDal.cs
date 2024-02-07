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
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EfMenuTableDal(SignalContext context) : base(context)
		{
		}

		public int MenuTableCount()
		{
			using var context = new SignalContext();

			return context.MenuTables.Count();
		}
	}
}
