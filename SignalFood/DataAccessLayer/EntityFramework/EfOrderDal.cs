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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalContext();	

			return context.Orders.Where(x => x.Description == "Aktif").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalContext();

			return context.Orders.OrderByDescending(x => x.OrderId).Take(1)     // z -> a
				.Select(y => y.TotalPrice).FirstOrDefault();	
		}

		public decimal TodayTotalPrice()
		{
			//using var context = new SignalContext();

			//return context.Orders.Where(x => x.OrderDate == DateTime.Parse(DateTime.Now.ToShortDateString()))
			//	.Sum(y => y.TotalPrice);
			return 0;
		}

		public int TotalOrderCount()
		{
			using var context = new SignalContext();

			return context.Orders.Count();
		}
	}
}
