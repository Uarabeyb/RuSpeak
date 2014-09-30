namespace RuSpeak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AudioContents", "AudioContentId", "dbo.Posts");
            DropForeignKey("dbo.PieceContents", "AudioContent_AudioContentId", "dbo.AudioContents");
            DropIndex("dbo.AudioContents", new[] { "AudioContentId" });
            DropPrimaryKey("dbo.AudioContents");
            AddColumn("dbo.AudioContents", "Post_PostId", c => c.Int());
            AlterColumn("dbo.AudioContents", "AudioContentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AudioContents", "AudioContentId");
            CreateIndex("dbo.AudioContents", "Post_PostId");
            AddForeignKey("dbo.AudioContents", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.PieceContents", "AudioContent_AudioContentId", "dbo.AudioContents", "AudioContentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PieceContents", "AudioContent_AudioContentId", "dbo.AudioContents");
            DropForeignKey("dbo.AudioContents", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.AudioContents", new[] { "Post_PostId" });
            DropPrimaryKey("dbo.AudioContents");
            AlterColumn("dbo.AudioContents", "AudioContentId", c => c.Int(nullable: false));
            DropColumn("dbo.AudioContents", "Post_PostId");
            AddPrimaryKey("dbo.AudioContents", "AudioContentId");
            CreateIndex("dbo.AudioContents", "AudioContentId");
            AddForeignKey("dbo.PieceContents", "AudioContent_AudioContentId", "dbo.AudioContents", "AudioContentId");
            AddForeignKey("dbo.AudioContents", "AudioContentId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
    }
}
