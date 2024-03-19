using Dapper;
using MfcLibrary.Core.MfcLibraryConnections;
using MfcLibrary.DAL.Abstract;
using MfcLibrary.DTO.BookDTOs;
using MfcLibrary.Entity;

namespace MfcLibrary.DAL.Concrete
{
    /// <summary>
    /// Data access layer class of Book.
    /// </summary>
    public class BookDal: IBookDal
    {
        private readonly DapperConnection _dapperConnection;

        /// <summary>
        /// Constructor of BookDal.
        /// </summary>
        /// <param name="dapperConnection"></param>
        public BookDal(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        /// <summary>
        /// Data access method for adding book to database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<int> AddBookAsync(Book book)
        {
            var sqlAddBookQuery = "INSERT INTO Book (BookName, Author, ImageUrl, CreatedDate, IsLoaned, IsActive, ModifiedDate) VALUES (@BookName, @Author, @ImageUrl, @CreatedDate , @IsLoaned, @IsActive, @ModifiedDate);";
            using var connection = _dapperConnection.CreateConnection();

            var addBookReturn = await connection.ExecuteAsync(sqlAddBookQuery, new
            {
                BookName = book.BookName,
                Author = book.Author,
                ImageUrl = book.ImageUrl,
                CreatedDate = DateTime.Now,
                IsLoaned = 0,
                IsActive = 1,
                ModifiedDate = DateTime.Now
            });

            return addBookReturn;
        }

        /// <summary>
        /// Data access method for lending book from library.
        /// </summary>
        /// <param name="lending"></param>
        /// <returns></returns>
        public async Task<int> BorrowBookAsync(Lending lending)
        {
            var sqlBorrowBookQuery = @"INSERT INTO Lending (BookID, BorrowerName, LoanDate, GiveBackDate) 
                               VALUES (@BookID, @BorrowerName, @LoanDate, @GiveBackDate);
                               UPDATE Book SET IsLoaned = 1 WHERE ID = @BookID;";

            using var connection = _dapperConnection.CreateConnection();

            var borrowBookReturn = await connection.ExecuteAsync(sqlBorrowBookQuery, new
            {
                lending.BookID,
                lending.BorrowerName,
                lending.LoanDate,
                lending.GiveBackDate
            });

            return borrowBookReturn;
        }

        /// <summary>
        /// Data access method for reading books from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookSelectDto>> GetBooksAsync()
        {
            var sqlGetBooksQuery = @"SELECT b.ID, b.BookName, b.Author, b.ImageUrl, b.IsLoaned, l.BorrowerName, l.GiveBackDate FROM Book b LEFT JOIN Lending l ON b.ID = l.BookID WHERE l.ID IS NULL OR (l.ID = (SELECT TOP 1 ID FROM Lending WHERE BookID = b.ID ORDER BY LoanDate DESC)) ORDER BY b.BookName;";

            using var connection = _dapperConnection.CreateConnection();

            var books = await connection.QueryAsync<BookSelectDto>(sqlGetBooksQuery);

            return books;
        }
    }
}
