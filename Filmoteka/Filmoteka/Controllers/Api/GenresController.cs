using Filmoteka.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Filmoteka.Controllers.Api
{
    public class GenresController : ApiController
    {
        private FilmotekaDataBaseModel context;

        public GenresController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET api/<controller>
        public IHttpActionResult GetGenres()
        {
            return Ok(context.Genres.Where(g => g.IsDeleted == false).ToList());
        }

        [HttpDelete]
        public void DeleteGenre(int id)
        {
            var genreInDb = context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            genreInDb.IsDeleted = true;

            context.SaveChanges();
        }
    }
}