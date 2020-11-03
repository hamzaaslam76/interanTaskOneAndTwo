namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteStoreProcedureStudet : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE DeleteStudent 
                    @StudentId int
                    AS
                    BEGIN
                    DELETE FROM DBO.Students WHERE StudentId = @StudentId
                    END");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE [dbo].[SelectAllCustomers]
                    GO
                    ");
        }
    }
}
