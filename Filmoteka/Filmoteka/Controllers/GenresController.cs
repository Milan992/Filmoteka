using Filmoteka.Models;
using System.Linq;
using System.Web.Mvc;

namespace Filmoteka.Controllers
{
    public class GenresController : Controller
    {
        private FilmotekaDataBaseModel context;

        public GenresController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            Genre model = new Genre();

            return View("GenresForm", model);
        }

        public ActionResult Edit(int id)
        {
            Genre genre = context.Genres.Where(g => g.IsDeleted == false).SingleOrDefault(g => g.Id == id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View("GenresForm", genre);
        }

        [HttpPost]
        public ActionResult Save(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View("GenresForm", genre);
            }

            if (genre.Id == 0)
            {
                context.Genres.Add(genre);
            }
            else
            {
               Genre genreInDb = context.Genres.SingleOrDefault(g => g.Id == genre.Id);

                if (genre == null)
                {
                    return HttpNotFound();
                }

                genreInDb.GenreName = genre.GenreName;
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}