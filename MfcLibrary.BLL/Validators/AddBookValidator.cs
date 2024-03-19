using FluentValidation;
using MfcLibrary.DTO.BookDTOs;

namespace MfcLibrary.BLL.Validators
{
    /// <summary>
    /// Validation of adding book.
    /// </summary>
    public class AddBookValidator : AbstractValidator<BookAddDto>
    {
        /// <summary>
        /// Rules of validation. These are sample validations. A better result can be achieved by detailing it according to customer requests.
        /// </summary>
        public AddBookValidator()
        {
            RuleFor(x => x.BookName).NotEmpty().WithMessage("Kitap adı boş olamaz.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar adı boş olamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL'si boş olamaz.");
        }
    }
}

