namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudentUsingStoreProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    CREATE PROCEDURE AddStudent 

                    @Studentname nvarchar(max),
                    @StudentEmail nvarchar(max),
                    @PhoneNumber nvarchar(max),
                    @DateOfBirth nvarchar(max),
                    @Password nvarchar(max),
                    @ConfirmPawword nvarchar(max),
                    @UserId int
                    
                    AS
                    begin
                    INSERT INTO dbo.Students
                    (
                    Studentname,
                    StudentEmail,
                    PhoneNumber,
                    DateOfBirth,
                    Password,
                    ConfirmPawword,
                    UserId
                     
                    )

                    VALUES
                    (
                    @Studentname,
                    @StudentEmail,
                    @PhoneNumber,
                    @DateOfBirth,
                    @Password,
                    @ConfirmPawword,
                    @UserId
                
                    )
                     select SCOPE_IDENTITY()
                    end
                ");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE [dbo].[AddStudent]
             GO");
        }
    }
}
