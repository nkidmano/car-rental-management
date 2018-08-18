namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
