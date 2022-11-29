using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Notifications
{
    public interface INotifier
    {
        #region Methods

        List<Notification> GetAllNotifications();

        void Handle(Notification notification);

        bool HasNotification();

        #endregion Methods
    }
}
