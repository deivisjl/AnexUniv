namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV30 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Icon", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Price", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            CreateIndex("dbo.UsersPerCourses", "UserId");
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Price", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Icon", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.UsersPerCourses", "UserId");
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
