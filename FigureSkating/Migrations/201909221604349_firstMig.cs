namespace FigureSkating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FigureSkaters", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FigureSkaters", "Age", c => c.Int(nullable: false));
        }
    }
}
