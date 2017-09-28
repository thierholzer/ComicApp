using Comic.Data.Dapper;
using Comic.Data.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
namespace ComicWebApp.API.Controllers
{
    [RoutePrefix("comicbook")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComicBookController : BaseApiController<ComicBook>
    {
        public ComicBookController(IRepository<ComicBook> repository) : base(repository)
        {

        }

    }
}