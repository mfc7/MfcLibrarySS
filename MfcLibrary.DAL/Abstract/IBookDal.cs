using MfcLibrary.DTO.BookDTOs;
using MfcLibrary.Entity;

namespace MfcLibrary.DAL.Abstract
{
    /// <summary>
    /// Data Access Layer Interface for Book.
    /// </summary>
    public interface IBookDal
    {
        /// <summary>
        /// Adding Book method of DAL.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Task<int> AddBookAsync(Book book);

        /// <summary>
        /// Borrow Book method of DAL.
        /// </summary>
        /// <param name="lending"></param>
        /// <returns></returns>
        public Task<int> BorrowBookAsync(Lending lending);

        /// <summary>
        /// Get Books method of DAL.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<BookSelectDto>> GetBooksAsync();
    }
}
