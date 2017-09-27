using Comic.Data.Dapper;
using Comic.Data.Models;
using System.Web.Http;
namespace ComicWebApp.API.Controllers
{
    [RoutePrefix("creator")]
    public class CreatorController : BaseApiController<Creator>
    {
        public CreatorController(IRepository<Creator> repository) : base(repository)
        {

        }
    }
}