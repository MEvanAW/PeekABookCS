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
        public IEnumerable<Book> FantasyBooks { get; private set; }
        public IEnumerable<Book> SelfHelpBooks { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BooksRepositoryService booksRepositoryService)
        {
            _logger = logger;
            BooksRepositoryService = booksRepositoryService;
            FantasyBooks = new List<Book>();
            SelfHelpBooks = new List<Book>();
        }

        public async Task OnGetAsync()
        {
            var fantasyTask = BooksRepositoryService.GetBooksBySubject("Fantasy", 3);
            var selfHelpTask = BooksRepositoryService.GetBooksBySubject("Self Help", 3);
            var tasks = new List<Task> { fantasyTask, selfHelpTask };
            while (tasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(tasks);
                if (finishedTask == fantasyTask)
                {
                    if (fantasyTask.Result != null)
                        FantasyBooks = fantasyTask.Result;
                } else
                {
                    if (selfHelpTask.Result != null)
                        SelfHelpBooks = selfHelpTask.Result;
                }
                tasks.Remove(finishedTask);
            }
        }
    }
}