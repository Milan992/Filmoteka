using Filmoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmoteka.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }

        public List<Actor> Actors { get; set; }
    }
}