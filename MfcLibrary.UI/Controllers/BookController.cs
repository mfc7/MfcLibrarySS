using Microsoft.AspNetCore.Mvc;
using MfcLibrary.BLL.Abstract;
using MfcLibrary.DTO.BookDTOs;
using MfcLibrary.DTO.LendingDTO;
using MfcLibrary.BLL.Validators;
using Serilog;

namespace MfcLibrary.Controllers
{
    /// <summary>
    /// Book Controller of Book Views.
    /// </summary>
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        /// <summary>
        /// Constructor of BookController.
        /// </summary>
        /// <param name="bookService"></param>
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Index view for Library.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync().ConfigureAwait(false);
            return View(books);
        }

        /// <summary>
        /// Get method of AddBook.
        /// </summary>
        /// <returns></returns>
        public IActionResult AddBook()
        {
            return View(new BookAddDto());
        }

        /// <summary>
        /// Post method of AddBook.
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookAddDto bookDto)
        {
            var validator = new AddBookValidator();
            var validationResult = await validator.ValidateAsync(bookDto);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
                Log.Error("An unhandled exception occurred while adding a book."); //Serilog

                TempData["Result"] = "Failed";
                TempData["AlertMessage"] = "Failed";

                return RedirectToAction(nameof(Index));
            }

            var result = await _bookService.AddBookAsync(bookDto);

            if (result != null)
            {
                TempData["Result"] = "Success";
                TempData["AlertMessage"] = "Success";
            }
            else
            {
                TempData["Result"] = "Failed";
                TempData["AlertMessage"] = "Failed";
            }

            ViewBag.AlertMessage = TempData["Result"];

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Post method of LoanBook.
        /// </summary>
        /// <param name="loanDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoanBook(LoanDto loanDto)
        {
            var validator = new LoanBookValidator();
            var validationResult = await validator.ValidateAsync(loanDto);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
                Log.Error("An unhandled exception occurred while loaning a book.");

                TempData["Result"] = "Failed";
                TempData["AlertMessage"] = "Failed";

                return RedirectToAction(nameof(Index));
            }

            var result = await _bookService.BorrowBookAsync(loanDto);

            if (result > 0)
            {
                TempData["Result"] = "Success";
                TempData["AlertMessage"] = "Success";
            }
            else
            {
                TempData["Result"] = "Failed";
                TempData["AlertMessage"] = "Failed";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
