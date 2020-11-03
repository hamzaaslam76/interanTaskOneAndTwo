namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropIndex("dbo.Students", new[] { "UserId" });
            DropColumn("dbo.Students", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "UserId");
            AddForeignKey("dbo.Students", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
