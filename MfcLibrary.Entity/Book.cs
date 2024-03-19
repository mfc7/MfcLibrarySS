namespace MfcLibrary.Entity
{
    /// <summary>
    /// Book Entities
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id of books.
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Names of books.
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Authors of books.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Path of images.
        /// </summary>
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
