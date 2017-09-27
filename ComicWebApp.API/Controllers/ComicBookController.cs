using Comic.Data.Dapper;
using Comic.Data.Models;
using System.Web.Http;

namespace ComicWebApp.API.Controllers
{
    [RoutePrefix("comicbook")]
    public class ComicBookController : BaseApiController<ComicBook>
    {
        public ComicBookController(IRepository<ComicBook> repository) : base(repository)
        {

        }

    }
}