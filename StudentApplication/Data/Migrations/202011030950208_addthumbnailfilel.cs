namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addthumbnailfilel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ThumbnailUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ThumbnailUrl");
        }
    }
}
