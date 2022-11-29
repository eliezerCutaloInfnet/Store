namespace Store.Domain.Notifications
{
    public class Notification
    {
        #region Constructors

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;

        }

        #endregion Constructors

        #region Properties

        public string Key { get; }

        public string Message { get; }

        #endregion Properties
    }
}
