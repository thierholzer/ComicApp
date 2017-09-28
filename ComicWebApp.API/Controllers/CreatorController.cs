using Comic.Data.Dapper;
using Comic.Data.Models;
using System.Web.Http;
using System.Web.Http.Cors;
namespace ComicWebApp.API.Controllers
{
    [RoutePrefix("creator")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CreatorController : BaseApiController<Creator>
    {
        public CreatorController(IRepository<Creator> repository) : base(repository)
        {

        }
    }
}