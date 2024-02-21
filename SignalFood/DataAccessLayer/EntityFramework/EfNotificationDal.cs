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
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByStatusFalse()
        {
            using var context = new SignalContext();

            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalContext();
            
            return context.Notifications.Where(x => x.Status == false).Count();
        }

		public void NotificationStatusChangeToFalse(int id)
		{
			using var context = new SignalContext();
			var value = context.Notifications.Find(id);
			value.Status = false;

			context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
            using var context = new SignalContext();
            var value = context.Notifications.Find(id);
            value.Status = true;

            context.SaveChanges();
        }

	}
}
