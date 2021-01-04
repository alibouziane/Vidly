namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1977-12-14' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '1988-12-14' WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate = '1987-12-14' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
