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

        public async Task<string> Index(string q)
        {
            if (q == null || q == "")
                return HtmlEncoder.Default.Encode("Empty result");
            var task = BooksRepositoryService.GetBooks(q, 8);
            var books = await task;
            if (books.Count() == 0)
                return HtmlEncoder.Default.Encode("Empty result");
            string returnString = "";
            foreach (var book in books)
            {
                returnString += HtmlEncoder.Default.Encode($"{book.Title}; ");
            }
            return returnString;
        }
    }
}
