using bbBookstore.Data;
using bbBookstore.Data.Services;
using bbBookstore.Data.Static;
using bbBookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bbBookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync(n => n.Publisher, n => n.Author);
            return View(allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Publisher, n => n.Author);

            if(!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allBooks.Where(n => n.BookTitle.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filterResult);
            }

            return View("Index", allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBooksByIdAsync(id);
            return View(bookDetail);
        }

        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FirstName");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if(!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FirstName");
                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                return View(book);
            }
            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBooksByIdAsync(id);

            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                BookTitle = bookDetails.BookTitle,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                BookImage = bookDetails.BookImage,
                BookGenre = bookDetails.BookGenre,
                NumOfPages = bookDetails.NumOfPages,
                ISBN = bookDetails.ISBN,
                Review = bookDetails.Review,
                PublisherId = bookDetails.PublisherId,
                AuthorId = bookDetails.AuthorId
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FirstName");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FirstName");
                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
