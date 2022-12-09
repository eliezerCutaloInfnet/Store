namespace Store.Application._shared
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
