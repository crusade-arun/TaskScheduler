namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projectmodelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "name", c => c.String(nullable: false));
        }
    }
}
