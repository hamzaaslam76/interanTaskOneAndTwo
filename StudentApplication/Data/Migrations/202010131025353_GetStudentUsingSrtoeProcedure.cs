namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetStudentUsingSrtoeProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE SelectAllStudent
                AS
                SELECT * FROM Students
                GO;");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE [dbo].[SelectAllStudent]
             GO");
        }
    }
}
