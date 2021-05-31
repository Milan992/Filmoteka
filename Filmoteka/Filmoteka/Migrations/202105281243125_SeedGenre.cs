namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into Genres(GenreName) values ('Horor');
                  insert into Genres(GenreName) values ('Thriller');
                  insert into Genres(GenreName) values ('Comedy');");

        }

        public override void Down()
        {
        }
    }
}
