using Filmoteka.Models;
using System.Collections.Generic;

namespace Filmoteka.ViewModels
{
    public class ActorsFormViewModel
    {
        public Person Person { get; set; }

        public Actor Actor { get; set; }

        public List<Movie> Movies { get; set; }
    }
}