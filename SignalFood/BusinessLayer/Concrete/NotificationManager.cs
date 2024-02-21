﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public void TAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void TDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public List<Notification> TGetAll()
		{
			return _notificationDal.GetAll();
		}

		public List<Notification> TGetAllNotificationByStatusFalse()
		{
			return _notificationDal.GetAllNotificationByStatusFalse();
		}

		public Notification TGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public int TNotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void TNotificationStatusChangeToFalse(int id)
		{
			_notificationDal.NotificationStatusChangeToFalse(id);
		}

		public void TNotificationStatusChangeToTrue(int id)
		{
			_notificationDal.NotificationStatusChangeToTrue(id);
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}
