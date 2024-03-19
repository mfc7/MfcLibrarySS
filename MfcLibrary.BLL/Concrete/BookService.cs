using MfcLibrary.BLL.Abstract;
using MfcLibrary.DAL.Abstract;
using MfcLibrary.DTO.BookDTOs;
using MfcLibrary.DTO.LendingDTO;
using MfcLibrary.Entity;

namespace MfcLibrary.BLL.Concrete
{
    /// <summary>
    /// Book Service class.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookDal bookDal;

        /// <summary>
        /// Constructor of BookService.
        /// </summary>
        /// <param name="bookDal"></param>
        public BookService(IBookDal bookDal)
        {
            this.bookDal = bookDal;
        }

        /// <summary>
        /// Method for adding books async. Data transfer object and anonymous types uesd.
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        public async Task<int> AddBookAsync(BookAddDto bookDto)
        {
            var book = new Book
            {
                BookName = bookDto.BookName,
                Author = bookDto.Author,
                ImageUrl = bookDto.ImageUrl
            };

            return await bookDal.AddBookAsync(book);
        }

        /// <summary>
        /// Method for loan books async. Data transfer object and anonymous types used.
        /// </summary>
        /// <param name="lendingDto"></param>
        /// <returns></returns>
        public async Task<int> BorrowBookAsync(LoanDto lendingDto)
        {
            var lending = new Lending
            {
                BookID = lendingDto.BookID, 
                BorrowerName = lendingDto.BorrowerName,
                GiveBackDate = lendingDto.GiveBackDate
            };

            return await bookDal.BorrowBookAsync(lending);
        }

        /// <summary>
        /// Method for read books from database async. Data transfer object used.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookSelectDto>> GetBooksAsync()
        {
            return await bookDal.GetBooksAsync();
        }
    }
}
