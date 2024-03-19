using MfcLibrary.DTO.BookDTOs;
using MfcLibrary.DTO.LendingDTO;

namespace MfcLibrary.BLL.Abstract
{
    /// <summary>
    /// Book Service Interface
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Adding Book method of Business Logic Layer.
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        Task<int> AddBookAsync(BookAddDto bookDto);

        /// <summary>
        /// Lending Book method of Business Logic Layer.
        /// </summary>
        /// <param name="lendingDto"></param>
        /// <returns></returns>
        Task<int> BorrowBookAsync(LoanDto lendingDto);

        /// <summary>
        /// Read Books method of Business Logic Layer.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookSelectDto>> GetBooksAsync();
    }
}
