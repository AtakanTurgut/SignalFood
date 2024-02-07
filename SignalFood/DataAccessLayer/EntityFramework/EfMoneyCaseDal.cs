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
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalContext context) : base(context)
		{
		}

		public decimal TotalMoneyCaseAmount()
		{
			using var context = new SignalContext();

			return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
		}
	}
}
