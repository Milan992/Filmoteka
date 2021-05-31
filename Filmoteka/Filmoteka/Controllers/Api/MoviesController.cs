using Filmoteka.Models;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;

namespace Filmoteka.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private FilmotekaDataBaseModel context;

        public MoviesController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET api/<controller>
        public IHttpActionResult GetMovies()
        {
            return Ok(context.Movies.Include(g => g.Genre).Include(d => d.Director).Include(d => d.Director.Person).Where(m => m.IsDeleted == false).ToList());
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            movieInDb.IsDeleted = true;

            context.SaveChanges();
        }
    }
}
