using System;
using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter movie's title.")]
        [StringLength(500, ErrorMessage = "Movie's title can be maximum 500 characters long.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Poster { get; set; }

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        public Genre Genre { get; set; }

        public Director Director { get; set; }

        public bool IsDeleted { get; set; }
    }
}