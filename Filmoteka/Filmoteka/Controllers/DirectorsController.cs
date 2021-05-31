using Filmoteka.Models;
using Filmoteka.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Filmoteka.Controllers
{
    public class DirectorsController : Controller
    {
        private FilmotekaDataBaseModel context;

        public DirectorsController()
        {
            context = new FilmotekaDataBaseModel();
        }

        // GET: Directors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            DirectorsFormViewModel DirectorsFormViewModel = new DirectorsFormViewModel()
            {
                Person = new Person(),
                Director = new Director()
            };

            return View("DirectorsForm", DirectorsFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            Person person = context.People.Where(p => p.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            Director Director = context.Directors.SingleOrDefault(a => a.PersonId == id);

            if (Director == null)
            {
                return HttpNotFound();
            }

            DirectorsFormViewModel DirectorsFormViewModel = new DirectorsFormViewModel()
            {
                Person = person,
                Director = Director
            };

            return View("DirectorsForm", DirectorsFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(DirectorsFormViewModel DirectorsFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("DirectorsForm", DirectorsFormViewModel);
            }

            if (DirectorsFormViewModel.Person.Id == 0)
            {
                Person person = DirectorsFormViewModel.Person;
                context.People.Add(person);
                context.SaveChanges();

                Director Director = new Director() { PersonId = person.Id };
                context.Directors.Add(Director);
            }
            else
            {
                Person personInDb = context.People.SingleOrDefault(p => p.Id == DirectorsFormViewModel.Person.Id);

                if (personInDb == null)
                {
                    return HttpNotFound();
                }

                personInDb.FirstName = DirectorsFormViewModel.Person.FirstName;
                personInDb.LastName = DirectorsFormViewModel.Person.LastName;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Directors");
        }
    }
}