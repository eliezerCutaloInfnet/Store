using FluentValidation;
using FluentValidation.Results;

namespace Store.Domain._shared
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }


        #region Methods

        public abstract bool IsValid();

        protected void AddErrors(ValidationResult validateResult)
        {
            foreach (var error in validateResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        #endregion Methods

    }
}
