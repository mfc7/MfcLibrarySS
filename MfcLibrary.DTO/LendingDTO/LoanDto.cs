using System.ComponentModel.DataAnnotations;

namespace MfcLibrary.DTO.LendingDTO
{
    public class LoanDto
    {
        /// <summary>
        /// BookID
        /// </summary>
        public int BookID { get; set; }

        /// <summary>
        /// BookName
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Name of person who loan book.
        /// </summary>
        [Required(ErrorMessage = "Ödünç alan ismi boş olamaz.")]
        public string BorrowerName { get; set; }

        /// <summary>
        /// Date of loan.
        /// </summary>
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// Return of book date.
        /// </summary>
        [Required(ErrorMessage = "Geri getirme tarihi boş olamaz.")]
        public DateTime GiveBackDate { get; set; }

    }
}
