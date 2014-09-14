using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RuSpeak.Models.Auth;
using RuSpeak.Models.Things;

namespace RuSpeak.Models
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AudioContent> AudioContents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
              HasMany(c => c.UserRoles).
              WithMany(p => p.Users).
              Map(
               m =>
               {
                   m.MapLeftKey("UserId");
                   m.MapRightKey("RoleId");
                   m.ToTable("UserRoles");
               });

            modelBuilder.Entity<Post>()
                .HasMany(p=>p.Comments)
                .WithRequired(c=>c.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .HasOptional(p=>p.AudioContent)
                .WithRequired(c => c.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Pieces)
                .WithRequired(c => c.Post)
                .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}