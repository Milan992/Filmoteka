using Filmoteka.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

namespace Filmoteka.Controllers.Api
{
    public class ActorsController : ApiController
    {
        private FilmotekaDataBaseModel context;

        public ActorsController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET api/<controller>
        public IHttpActionResult GetActors()
        {
            return Ok(context.Actors.Include(p => p.Person).Where(p => p.Person.IsDeleted == false).ToList());
        }

        [HttpDelete]
        public void DeleteActor(int id)
        {
            var actorInDb = context.Actors.SingleOrDefault(a => a.PersonId == id);

            if (actorInDb == null)
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