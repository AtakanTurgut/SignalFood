using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
		{
			_moneyCaseDal.Add(entity);
		}

		public void TDelete(MoneyCase entity)
		{
			_moneyCaseDal.Delete(entity);
		}

		public List<MoneyCase> TGetAll()
		{
			return	_moneyCaseDal.GetAll();
		}

		public MoneyCase TGetById(int id)
		{
			return _moneyCaseDal.GetById(id);
		}

		public decimal TTotalMoneyCaseAmount()
		{
			return	_moneyCaseDal.TotalMoneyCaseAmount();
		}

		public void TUpdate(MoneyCase entity)
		{
			_moneyCaseDal.Update(entity);
		}

	}
}
