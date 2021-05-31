namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Genres", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsDeleted");
            DropColumn("dbo.Genres", "IsDeleted");
            DropColumn("dbo.People", "IsDeleted");
        }
    }
}
