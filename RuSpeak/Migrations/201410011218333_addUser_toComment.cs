namespace RuSpeak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUser_toComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserPosted_UserId", c => c.Int());
            CreateIndex("dbo.Comments", "UserPosted_UserId");
            AddForeignKey("dbo.Comments", "UserPosted_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserPosted_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserPosted_UserId" });
            DropColumn("dbo.Comments", "UserPosted_UserId");
        }
    }
}
