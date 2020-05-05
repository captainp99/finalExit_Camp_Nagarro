namespace _03_Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingDataEntity", "CellPhone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingDataEntity", "CellPhone", c => c.Int(nullable: false));
        }
    }
}
