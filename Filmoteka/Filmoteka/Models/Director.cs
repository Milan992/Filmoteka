
namespace Filmoteka.Models
{
    public class Director
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}