
namespace Filmoteka.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? MovieId { get; set; }

        public Person Person { get; set; }

        public Movie Movie { get; set; }
    }
}