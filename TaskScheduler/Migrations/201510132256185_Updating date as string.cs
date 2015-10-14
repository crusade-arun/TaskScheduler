namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatingdateasstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "startDate", c => c.String());
            AlterColumn("dbo.Projects", "endDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "endDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "startDate", c => c.DateTime(nullable: false));
        }
    }
}
