using PeekABookWebApp.Models;

namespace PeekABookWebApp.Services
{
    public class BooksRepositoryService
    {
        private readonly string _baseUrl;
        private readonly string _booksApiKey;
        public BooksRepositoryService(IConfiguration configuration)
        {
            _baseUrl = configuration["GoogleBooksUrl"];
            _booksApiKey = configuration["BooksApiKey"];
        }
        public async Task<IEnumerable<Book>> GetBooks(string q, int maxResults)
        {
            q = q.Replace(' ', '+');
            List<Book> books = new List<Book>();
            using (var client = new HttpClient())
            {
                // Passing service base URL
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Sending request to find web api REST service resource Volumes using HttpClient
                var response = await client.GetAsync("volumes?langRestrict=en&filter=full&orderBy=newest&fields=items(volumeInfo/title,volumeInfo/authors,volumeInfo/averageRating,volumeInfo/pageCount,volumeInfo/description,volumeInfo/categories,volumeInfo/imageLinks/*,volumeInfo/previewLink)&key="
                    + _booksApiKey +
                    "&q=" + q +
                    "&maxResults=" + maxResults);
                if (response.IsSuccessStatusCode)
                {
                    BooksApiResponse? booksApiResponse = await response.Content.ReadFromJsonAsync<BooksApiResponse>();
                    if (booksApiResponse != null)
                    if (booksApiResponse.Items != null)
                    {
                        foreach (Item item in booksApiResponse.Items)
                        {
                            if (item.Book != null)
                            {
                                books.Add(item.Book);
                            }
                        }
                    }
                }
            }
            return books;
        }
    }
}
