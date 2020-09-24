namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertLastChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CreatedUtc");
        }
    }
}
