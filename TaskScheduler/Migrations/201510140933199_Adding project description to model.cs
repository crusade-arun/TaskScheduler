namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingprojectdescriptiontomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "projectDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "projectDesc");
        }
    }
}
