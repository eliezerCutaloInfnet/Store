using FluentValidation.Results;

namespace Store.Application._shared
{
    public class AppService
    {
        #region Fields

        private readonly INotifier _notifier;

        #endregion Fields

        #region Constructor
        public AppService(INotifier notifier)
        {
            _notifier = notifier;
        }
        #endregion Constructor

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notify(error.PropertyName, error.ErrorMessage);
        }

        protected void Notify(string key, string mensagem)
        {
            _notifier.Handle(new Notification(key, mensagem));
        }

        protected List<Notification> GetAllNotifications()
        {
            return _notifier.GetAllNotifications();
        }
    }
}
