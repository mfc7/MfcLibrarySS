using System.ComponentModel.DataAnnotations;

namespace MfcLibrary.DTO.BookDTOs
{
    public class BookAddDto
    {
        /// <summary>
        /// Names of books.
        /// </summary>
        [Required(ErrorMessage = "Kitap adı boş olamaz.")]
        public string BookName { get; set; }

        /// <summary>
        /// Authors of books.
        /// </summary>
        [Required(ErrorMessage = "Yazar adı boş olamaz.")]
        public string Author { get; set; }

        /// <summary>
        /// Path of images.
        /// </summary>
        [Required(ErrorMessage = "Resim URL'si boş olamaz.")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Book loaned situation.
        /// </summary>
        public bool IsLoaned { get; set; }

        /// <summary>
        /// Whether the books appears in the list or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Created date of books.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Modified date of books.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
