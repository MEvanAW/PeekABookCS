using Microsoft.AspNetCore.Mvc;
using PeekABookWebApp.Services;
using System.Text.Encodings.Web;

namespace PeekABookWebApp.Controllers
{
    [Route("[controller]")]
    public class SearchController : Controller
    {
        public BooksRepositoryService BooksRepositoryService;
        public SearchController(BooksRepositoryService booksRepositoryService)
        {
            BooksRepositoryService = booksRepositoryService;
        }

        public async Task<IActionResult> Index(string q)
        {
            if (q == null || q == "")
            {
                ViewData["books"] = new List<Models.Book>();
                return View();
            }
            var task = BooksRepositoryService.GetBooks(q, 8);
            var books = await task;
            ViewData["books"] = books;
            return View();
        }
    }
}
