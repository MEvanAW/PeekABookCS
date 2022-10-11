using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PeekABookWebApp.Controllers
{
    [Route("[controller]")]
    public class SearchController : Controller
    {
        public string Index(string q)
        {
            return HtmlEncoder.Default.Encode($"The result of {q}");
        }
    }
}
