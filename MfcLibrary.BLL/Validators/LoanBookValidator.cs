using FluentValidation;
using MfcLibrary.DTO.LendingDTO;

namespace MfcLibrary.BLL.Validators
{
    /// <summary>
    /// Validation of lending books.
    /// </summary>
    public class LoanBookValidator : AbstractValidator<LoanDto>
    {
        /// <summary>
        /// Rules for lending book validation. These are sample validations. A better result can be achieved by detailing it according to requests.
        /// </summary>
        public LoanBookValidator()
        {
            RuleFor(x => x.BorrowerName).NotEmpty().WithMessage("Ödünç alan kişi adı boş olamaz.");
            RuleFor(x => x.GiveBackDate).NotEmpty().WithMessage("Geri getirme tarihi boş olamaz.");
            RuleFor(x => x.GiveBackDate).GreaterThan(DateTime.Now).WithMessage("Geri getirme tarihi bugünden ileri bir tarih olmalıdır.");
        }
    }
}
