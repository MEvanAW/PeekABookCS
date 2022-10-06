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
        public IEnumerable<Book> TechnologyBooks { get; private set; }
        public IEnumerable<Book> BusinessBooks { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BooksRepositoryService booksRepositoryService)
        {
            _logger = logger;
            BooksRepositoryService = booksRepositoryService;
            TechnologyBooks = new List<Book>();
            BusinessBooks = new List<Book>();
        }

        public async Task OnGetAsync()
        {
            var technologyTask = BooksRepositoryService.GetBooksBySubject("Technology", 4);
            var businessTask = BooksRepositoryService.GetBooksBySubject("Business", 4);
            var tasks = new List<Task> { technologyTask, businessTask };
            while (tasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(tasks);
                if (finishedTask == technologyTask)
                {
                    if (technologyTask.Result != null)
                        TechnologyBooks = technologyTask.Result;
                } else
                {
                    if (businessTask.Result != null)
                        BusinessBooks = businessTask.Result;
                }
                tasks.Remove(finishedTask);
            }
        }
    }
}