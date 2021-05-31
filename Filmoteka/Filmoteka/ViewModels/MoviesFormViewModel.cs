using Filmoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmoteka.ViewModels
{
    public class MoviesFormViewModel
    {
        public Movie Movie { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Director> Directors { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}