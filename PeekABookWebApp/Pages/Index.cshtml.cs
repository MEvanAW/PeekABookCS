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
        public Book Book { get; private set; }
        public string Src { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BooksRepositoryService booksRepositoryService)
        {
            _logger = logger;
            BooksRepositoryService = booksRepositoryService;
            Book = new Book();
            Src = "";
        }

        public void OnGet()
        {
            var task = BooksRepositoryService.GetBooks("Biography");
            var result = task.Result;
            if (result != null)
            {
                Book = result.First();
                if (Book.ImageLinks != null)
                    Src = Book.ImageLinks.Src();
            }
        }
    }
}