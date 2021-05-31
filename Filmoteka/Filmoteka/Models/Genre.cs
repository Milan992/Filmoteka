using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter genre name.")]
        [StringLength(300, ErrorMessage = "Genre name can be maximum 300 characters long.")]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        public bool IsDeleted { get; set; }
    }
}