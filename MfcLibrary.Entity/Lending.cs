namespace MfcLibrary.Entity
{
    /// <summary>
    /// Lending System Entities
    /// </summary>
    public class Lending
    {
        /// <summary>
        /// ID for per loan.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// BookID
        /// </summary>
        public int BookID { get; set; }

        /// <summary>
        /// Name of person who loan book.
        /// </summary>
        public string BorrowerName { get; set; }

        /// <summary>
        /// Date of loan.
        /// </summary>
        public DateTime LoanDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Return of book date.
        /// </summary>
        public DateTime GiveBackDate { get; set; }

    }
}
