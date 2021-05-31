using Filmoteka.Models;
using Filmoteka.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Filmoteka.Controllers
{
    public class MoviesController : Controller
    {
        private FilmotekaDataBaseModel context;

        public MoviesController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            MoviesFormViewModel moviesFormViewModel = new MoviesFormViewModel()
            {
                Movie = new Movie(),
                Genres = context.Genres.Where(g => g.IsDeleted == false).ToList(),
                Directors = context.Directors.Include(p => p.Person).Where(d => d.Person.IsDeleted == false).ToList()
            };

            return View("MoviesForm", moviesFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            MoviesFormViewModel moviesFormViewModel = new MoviesFormViewModel()
            {
                Movie = movie,
                Genres = context.Genres.Where(g => g.IsDeleted == false).ToList(),
                Directors = context.Directors.Include(p => p.Person).Where(d => d.Person.IsDeleted == false).ToList()
            };

            return View("MoviesForm", moviesFormViewModel);
        }

        public ActionResult Details(int id)
        {
            Movie movie = context.Movies.Include(g => g.Genre).Include(d => d.Director).Include(d => d.Director.Person).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel()
            {
                Movie = movie,
                Actors = context.Actors.Include(p => p.Person).Where(a => a.MovieId == id).ToList()
            };

            return View("Details", movieDetailsViewModel);
        }

        public ActionResult Save(MoviesFormViewModel moviesFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                moviesFormViewModel.Genres = context.Genres.Where(g => g.IsDeleted == false).ToList();
                moviesFormViewModel.Directors = context.Directors.Include(p => p.Person).Where(d => d.Person.IsDeleted == false).ToList();

                return View("MoviesForm", moviesFormViewModel);
            }

            // Save poster file to app data folder and save it's adress in database
            if (moviesFormViewModel.File != null && moviesFormViewModel.File.ContentLength > 0)
            {
                var path = Server.MapPath("~/App_Data/Posters/") + moviesFormViewModel.File.FileName;

                moviesFormViewModel.File.SaveAs(path);

                moviesFormViewModel.Movie.Poster = moviesFormViewModel.File.FileName;
            }

            if (moviesFormViewModel.Movie.Id == 0)
            {
                context.Movies.Add(moviesFormViewModel.Movie);
            }
            else
            {
                Movie movieInDb = context.Movies.SingleOrDefault(m => m.Id == moviesFormViewModel.Movie.Id);

                if (movieInDb == null)
                {
                    return HttpNotFound();
                }

                movieInDb.Title = moviesFormViewModel.Movie.Title;
                movieInDb.ReleaseDate = moviesFormViewModel.Movie.ReleaseDate;
                movieInDb.GenreId = moviesFormViewModel.Movie.GenreId;
                movieInDb.DirectorId = moviesFormViewModel.Movie.DirectorId;
                movieInDb.Poster = moviesFormViewModel.Movie.Poster;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}