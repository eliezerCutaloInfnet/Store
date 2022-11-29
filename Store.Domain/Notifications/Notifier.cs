namespace Store.Domain.Notifications
{
    public class Notifier
    {
        #region Fields

        private readonly List<Notification> _notifications;

        #endregion Fields

        #region Constructors

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        #endregion Constructors

        #region Methods

        public List<Notification> GetAllNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }
        public bool HasNotification()
        {
            return _notifications.Any();
        }

        #endregion Methods
    }
}
