namespace _03_Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingSchemaChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookingDataEntity", new[] { "CampId" });
            AddColumn("dbo.BookingDataEntity", "BillingAddress", c => c.String(nullable: false));
            AddColumn("dbo.BookingDataEntity", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.BookingDataEntity", "Country", c => c.String(nullable: false));
            AddColumn("dbo.BookingDataEntity", "State", c => c.String(nullable: false));
            AddColumn("dbo.BookingDataEntity", "CellPhone", c => c.Int(nullable: false));
            AddColumn("dbo.BookingDataEntity", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.BookingDataEntity", "ReferenceID", c => c.String(maxLength: 8, unicode: false));
            CreateIndex("dbo.BookingDataEntity", "CampID");
            CreateIndex("dbo.BookingDataEntity", "ReferenceID", unique: true);
            DropColumn("dbo.BookingDataEntity", "TotalPrice");
            DropColumn("dbo.BookingDataEntity", "Address");
            DropColumn("dbo.BookingDataEntity", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingDataEntity", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.BookingDataEntity", "Address", c => c.String(nullable: false));
            AddColumn("dbo.BookingDataEntity", "TotalPrice", c => c.Double(nullable: false));
            DropIndex("dbo.BookingDataEntity", new[] { "ReferenceID" });
            DropIndex("dbo.BookingDataEntity", new[] { "CampID" });
            AlterColumn("dbo.BookingDataEntity", "ReferenceID", c => c.String(nullable: false));
            DropColumn("dbo.BookingDataEntity", "TotalAmount");
            DropColumn("dbo.BookingDataEntity", "CellPhone");
            DropColumn("dbo.BookingDataEntity", "State");
            DropColumn("dbo.BookingDataEntity", "Country");
            DropColumn("dbo.BookingDataEntity", "ZipCode");
            DropColumn("dbo.BookingDataEntity", "BillingAddress");
            CreateIndex("dbo.BookingDataEntity", "CampId");
        }
    }
}
