using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeekABookWebApp.Models;
using PeekABookWebApp.Services;

namespace PeekABookWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public BooksRepositoryService BooksRepositoryService;
        public IEnumerable<Book> Books { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BooksRepositoryService booksRepositoryService)
        {
            _logger = logger;
            BooksRepositoryService = booksRepositoryService;
            Books = new List<Book>();
        }

        public void OnGet()
        {
            var task = BooksRepositoryService.GetBooks("Fantasy", 3);
            var result = task.Result;
            if (result != null)
                Books = result;
        }
    }
}