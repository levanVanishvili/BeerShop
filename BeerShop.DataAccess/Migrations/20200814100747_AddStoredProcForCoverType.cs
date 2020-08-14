using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerShop.DataAccess.Migrations
{
    public partial class AddStoredProcForCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetContainerTypes
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.ContainerTypes
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetContainerType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.ContainerTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateContainerType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.ContainerTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteContainerType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.ContainerTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateContainerType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.ContainerTypes(Name)
                                    VALUES (@Name)
                                   END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetContainerTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetContainerType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateContainerType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteContainerType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateContainerType");
        }
    }
}
