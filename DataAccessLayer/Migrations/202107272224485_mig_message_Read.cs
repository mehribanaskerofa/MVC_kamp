namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_Read : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Read");
        }
    }
}
