namespace RuSpeak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ololowa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AudioContents",
                c => new
                    {
                        AudioContentId = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                        AudioStream = c.Binary(),
                    })
                .PrimaryKey(t => t.AudioContentId)
                .ForeignKey("dbo.Posts", t => t.AudioContentId, cascadeDelete: true)
                .Index(t => t.AudioContentId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Header = c.String(maxLength: 4000),
                        Content = c.String(maxLength: 4000),
                        UserPosted_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserPosted_UserId)
                .Index(t => t.UserPosted_UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        ToComment_CommentId = c.Int(),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Comments", t => t.ToComment_CommentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.ToComment_CommentId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.PieceContents",
                c => new
                    {
                        PieceContentId = c.Int(nullable: false, identity: true),
                        Header = c.String(maxLength: 4000),
                        Content = c.String(maxLength: 4000),
                        AudioContent_AudioContentId = c.Int(),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PieceContentId)
                .ForeignKey("dbo.AudioContents", t => t.AudioContent_AudioContentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.AudioContent_AudioContentId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        RegisterDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 4000),
                        UserName = c.String(maxLength: 4000),
                        Password = c.String(maxLength: 4000),
                        Avatar = c.Binary(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserPosted_UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.PieceContents", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.PieceContents", "AudioContent_AudioContentId", "dbo.AudioContents");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "ToComment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.AudioContents", "AudioContentId", "dbo.Posts");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.PieceContents", new[] { "Post_PostId" });
            DropIndex("dbo.PieceContents", new[] { "AudioContent_AudioContentId" });
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.Comments", new[] { "ToComment_CommentId" });
            DropIndex("dbo.Posts", new[] { "UserPosted_UserId" });
            DropIndex("dbo.AudioContents", new[] { "AudioContentId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.PieceContents");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.AudioContents");
        }
    }
}
