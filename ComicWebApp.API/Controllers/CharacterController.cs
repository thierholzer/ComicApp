using Comic.Data.Dapper;
using Comic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
namespace ComicWebApp.API.Controllers
{
    [RoutePrefix("character")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CharacterController : BaseApiController<Character>
    {
        public CharacterController(IRepository<Character> repository) : base(repository)
        {

        }

    }
}