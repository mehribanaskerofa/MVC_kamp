namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_admin_roles_elaqe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RoleID", c => c.Int());
            CreateIndex("dbo.Admins", "RoleID");
            AddForeignKey("dbo.Admins", "RoleID", "dbo.Roles", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "RoleID", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleID" });
            DropColumn("dbo.Admins", "RoleID");
        }
    }
}
