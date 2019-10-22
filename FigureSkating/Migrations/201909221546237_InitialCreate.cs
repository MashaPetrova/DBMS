namespace FigureSkating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FigureSkaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FigureSkaterCompetitions",
                c => new
                    {
                        FigureSkater_Id = c.Int(nullable: false),
                        Competition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FigureSkater_Id, t.Competition_Id })
                .ForeignKey("dbo.FigureSkaters", t => t.FigureSkater_Id, cascadeDelete: true)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id, cascadeDelete: true)
                .Index(t => t.FigureSkater_Id)
                .Index(t => t.Competition_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FigureSkaterCompetitions", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.FigureSkaterCompetitions", "FigureSkater_Id", "dbo.FigureSkaters");
            DropIndex("dbo.FigureSkaterCompetitions", new[] { "Competition_Id" });
            DropIndex("dbo.FigureSkaterCompetitions", new[] { "FigureSkater_Id" });
            DropTable("dbo.FigureSkaterCompetitions");
            DropTable("dbo.FigureSkaters");
            DropTable("dbo.Competitions");
        }
    }
}
