namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv30 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Icon", c => c.String(nullable: false));
            AlterColumn("dbo.CourseLessonsLearnedPerStudents", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Price", c => c.String(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UsersPerCourses", "UserId");
            CreateIndex("dbo.CourseLessonsLearnedPerStudents", "UserId");
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            AddForeignKey("dbo.CourseLessonsLearnedPerStudents", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String());
            AlterColumn("dbo.Courses", "Price", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String());
            AlterColumn("dbo.CourseLessonsLearnedPerStudents", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Categories", "Icon", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.UsersPerCourses", "UserId");
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            CreateIndex("dbo.CourseLessonsLearnedPerStudents", "UserId");
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CourseLessonsLearnedPerStudents", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
