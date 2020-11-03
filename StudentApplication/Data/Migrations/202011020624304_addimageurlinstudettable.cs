namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimageurlinstudettable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ImageUrl");
        }
    }
}
