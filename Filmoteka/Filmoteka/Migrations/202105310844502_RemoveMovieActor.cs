namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMovieActor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieActors", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "MovieId" });
            DropIndex("dbo.MovieActors", new[] { "ActorId" });
            DropTable("dbo.MovieActors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(),
                        ActorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MovieActors", "ActorId");
            CreateIndex("dbo.MovieActors", "MovieId");
            AddForeignKey("dbo.MovieActors", "MovieId", "dbo.Movies", "Id");
            AddForeignKey("dbo.MovieActors", "ActorId", "dbo.Actors", "Id");
        }
    }
}
