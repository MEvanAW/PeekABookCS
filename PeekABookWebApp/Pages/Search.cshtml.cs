using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeekABookWebApp.Models;
using PeekABookWebApp.Services;

namespace PeekABookWebApp.Pages
{
    public class SearchModel : PageModel
    {
        public BooksRepositoryService BooksRepositoryService;
        public IEnumerable<Book> ResultBooks { get; private set; }
        public string Q { get; private set; }
        public SearchModel(BooksRepositoryService booksRepositoryService)
        {
            BooksRepositoryService = booksRepositoryService;
            ResultBooks = new List<Book>();
            Q = "";
        }
        public async Task OnGetAsync(string q)
        {
            if (q == null || q.Length == 0)
            {
                return;
            }
            var task = BooksRepositoryService.GetBooksBySubject(q, 8);
            Q = q;
            ResultBooks = await task;
        }
    }
}
