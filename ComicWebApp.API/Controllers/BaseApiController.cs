using Comic.Data.Dapper;
using Comic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ComicWebApp.API.Controllers
{
    public abstract class BaseApiController<T> : ApiController where T : EntityBase
    {
        private readonly IRepository<T> _repository;

        public IRepository<T> Repository
        {
            get
            {
                return _repository;
            }
            private set { }
        }
        public BaseApiController(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get By Id for an Entity
        /// </summary>
        /// <param name="id">id of entity</param>
        /// <returns>404 if not found or 200 if item is returned</returns>
        [Route("{id:int}")]
        [HttpGet]
        public virtual IHttpActionResult GetById(int id)
        {
            T result = _repository.FindByID(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <remarks>
        /// Gets all of current model
        /// </remarks>
        /// <returns>IEnumerable of Type T</returns>
        [Route("")]
        [HttpGet]
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.FindAll();
        }

        /// <summary>
        /// Adds new Entity Record
        /// </summary>
        /// <param name="item">entity</param>
        /// <returns>The id of the entity if successfully added</returns>
        [Route("")]
        [HttpPost]
        public virtual HttpResponseMessage Post([FromBody] T item)
        {
            long id = _repository.Add(item);

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + "/" + id);

            return response;
        }

        /// <summary>
        /// Updates an existing entity record
        /// </summary>
        /// <param name="item">the entity record</param>
        /// <returns>404 not found if record cannot be found to be updated, or 200 if successfully updated</returns>
        [Route("")]
        [HttpPut]
        public virtual IHttpActionResult Put([FromBody] T item)
        {
            var result = _repository.FindByID(item.Id);

            if (result == null)
                return NotFound();

            _repository.Update(item);

            return Ok(item);
        }

        /// <summary>
        /// Deletes a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>204 no content if delete is successful, 500 if delete fails</returns>
        [Route("{id:int}")]
        [HttpDelete]
        public virtual HttpResponseMessage Delete(int id)
        {
            T item = _repository.FindByID(id);
            if (item != null)
            {
                _repository.Remove(item);
                return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}