using Filmoteka.Models;
using Filmoteka.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Filmoteka.Controllers
{
    public class ActorsController : Controller
    {
        private FilmotekaDataBaseModel context;

        public ActorsController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET: Actors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            ActorsFormViewModel actorsFormViewModel = new ActorsFormViewModel()
            {
                Person = new Person(),
                Actor = new Actor(),
                Movies = context.Movies.Where(m => m.IsDeleted == false).ToList()
            };
            actorsFormViewModel.Movies.Add(null);

            return View("ActorsForm", actorsFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            Person person = context.People.Where(p => p.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            Actor actor = context.Actors.SingleOrDefault(a => a.PersonId == id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            ActorsFormViewModel actorsFormViewModel = new ActorsFormViewModel()
            {
                Person = person,
                Actor = actor,
                Movies = context.Movies.Where(m => m.IsDeleted == false).ToList()
            };
            actorsFormViewModel.Movies.Add(null);

            return View("ActorsForm", actorsFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(ActorsFormViewModel actorsFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                actorsFormViewModel.Movies = context.Movies.Where(m => m.IsDeleted == false).ToList();
                actorsFormViewModel.Movies.Add(null);

                return View("ActorsForm", actorsFormViewModel);
            }

            if (actorsFormViewModel.Person.Id == 0)
            {
                Person person = actorsFormViewModel.Person;
                context.People.Add(person);
                context.SaveChanges();

                Actor actor = new Actor() { PersonId = person.Id};
                context.Actors.Add(actor);
            }
            else
            {
                Person personInDb = context.People.SingleOrDefault(p => p.Id == actorsFormViewModel.Person.Id);

                if (personInDb == null)
                {
                    return HttpNotFound();
                }

                personInDb.FirstName = actorsFormViewModel.Person.FirstName;
                personInDb.LastName = actorsFormViewModel.Person.LastName;

                Actor actorInDb = context.Actors.SingleOrDefault(p => p.PersonId == actorsFormViewModel.Person.Id);

                actorInDb.MovieId = actorsFormViewModel.Actor.MovieId;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Actors");
        }
    }
}