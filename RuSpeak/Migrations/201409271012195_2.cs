namespace RuSpeak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateLastEdited", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateLastEdited", c => c.DateTime(nullable: false));
        }
    }
}
