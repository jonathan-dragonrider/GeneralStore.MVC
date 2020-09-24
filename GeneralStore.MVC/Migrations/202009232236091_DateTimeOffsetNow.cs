namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeOffsetNow : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "CreatedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
