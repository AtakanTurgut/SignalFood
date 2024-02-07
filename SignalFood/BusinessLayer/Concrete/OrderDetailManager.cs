﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal)
		{
			_orderDetailDal = orderDetailDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
		}

		public void TDelete(OrderDetail entity)
		{
			_orderDetailDal.Delete(entity);
		}

		public List<OrderDetail> TGetAll()
		{
			return _orderDetailDal.GetAll();
		}

		public OrderDetail TGetById(int id)
		{
			return _orderDetailDal.GetById(id);
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderDetailDal.Update(entity);
		}

	}
}
