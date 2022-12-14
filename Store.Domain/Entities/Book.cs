using FluentValidation;
using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class Book : Entity<Book>
    {
        public Book(string title, string genre, string summary, string isbn)
        {
            Title = title;
            Genre = genre;
            Summary = summary;
            Isbn = isbn;
        }

        public void Update(string title, string genre, string summary)
        {
            Title = title;
            Genre = genre;
            Summary = summary;
        }

        public string Title { get; private set; }
        public string Genre { get; private set; }
        public string Summary { get; private set; }
        public string Isbn { get; private set; }


        public override bool IsValid()
        {
            ValidateTitle();
            ValidateGenre();
            ValidateSummary();

            return ValidationResult.IsValid;
        }

        private void ValidateTitle()
        {
            RuleFor(i => i.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty");
        }

        private void ValidateGenre()
        {
            RuleFor(i => i.Genre)
                .NotEmpty()
                .WithMessage("Genre cannot be empty");
        }

        private void ValidateSummary()
        {
            RuleFor(i => i.Summary)
                .NotEmpty()
                .WithMessage("Summary cannot be empty");
        }

        private void ValidateIsbn()
        {
            RuleFor(i => i.Isbn)
                .NotEmpty()
                .WithMessage("Isbn cannot be empty");
        }


    }
}
