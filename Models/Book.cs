using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Models
{
    [PrimaryKey(nameof(Isbn))]
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;

        [Range(0, 10)]
        public int? Rating { get; set; }
    }

    public class BookModelFluentValidator : AbstractValidator<Book>
    {
        public BookModelFluentValidator()
        {
            RuleFor(x => x.Isbn)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(1,200);

            RuleFor(x => x.Author)
                .NotEmpty()
                .Length(1,200);
            
            RuleFor(x => x.Summary)
                .NotEmpty()
                .Length(0,200);

            RuleFor(x => x.Rating)
                .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Book>.CreateWithOptions((Book)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}