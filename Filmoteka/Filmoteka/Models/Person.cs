using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter person's first name.")]
        [StringLength(300, ErrorMessage = "Person's first name can be maximum 300 characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter person's last name.")]
        [StringLength(300, ErrorMessage = "Person's last name can be maximum 300 characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
    }
}