namespace Filmoteka.Models
{
    using System.Data.Entity;

    public class FilmotekaDataBaseModel : DbContext
    {
        // Your context has been configured to use a 'FilmotekaDataBaseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Filmoteka.Models.FilmotekaDataBaseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FilmotekaDataBaseModel' 
        // connection string in the application configuration file.
        public FilmotekaDataBaseModel()
            : base("name=FilmotekaDataBaseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

    }
}