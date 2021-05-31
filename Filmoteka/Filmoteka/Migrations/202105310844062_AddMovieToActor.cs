namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieToActor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "MovieId", c => c.Int());
            CreateIndex("dbo.Actors", "MovieId");
            AddForeignKey("dbo.Actors", "MovieId", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actors", "MovieId", "dbo.Movies");
            DropIndex("dbo.Actors", new[] { "MovieId" });
            DropColumn("dbo.Actors", "MovieId");
        }
    }
}
