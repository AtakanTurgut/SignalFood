using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationByStatusFalse();

		void TNotificationStatusChangeToTrue(int id);
		void TNotificationStatusChangeToFalse(int id);

	}
}
