namespace _03_Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingSchemaChange2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookingDataEntity", new[] { "CampID" });
            DropIndex("dbo.BookingDataEntity", new[] { "ReferenceID" });
            AlterColumn("dbo.BookingDataEntity", "ReferenceId", c => c.String(nullable: false, maxLength: 8, unicode: false));
            CreateIndex("dbo.BookingDataEntity", "CampId");
            CreateIndex("dbo.BookingDataEntity", "ReferenceId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookingDataEntity", new[] { "ReferenceId" });
            DropIndex("dbo.BookingDataEntity", new[] { "CampId" });
            AlterColumn("dbo.BookingDataEntity", "ReferenceId", c => c.String(maxLength: 8, unicode: false));
            CreateIndex("dbo.BookingDataEntity", "ReferenceID", unique: true);
            CreateIndex("dbo.BookingDataEntity", "CampID");
        }
    }
}
