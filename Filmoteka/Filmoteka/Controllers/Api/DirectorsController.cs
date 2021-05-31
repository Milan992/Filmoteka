using Filmoteka.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

namespace Filmoteka.Controllers.Api
{
    public class DirectorsController : ApiController
    {
        private FilmotekaDataBaseModel context;

        public DirectorsController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET api/<controller>
        public IHttpActionResult GetDirectors()
        {
            return Ok(context.Directors.Include(p => p.Person).Where(p => p.Person.IsDeleted == false).ToList());
        }

        [HttpDelete]
        public void DeleteDirector(int id)
        {
            var directorInDb = context.Directors.SingleOrDefault(a => a.PersonId == id);

            if (directorInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var personInDb = context.People.SingleOrDefault(p => p.Id == id);

            if (personInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            personInDb.IsDeleted = true;

            context.SaveChanges();
        }
    }
}