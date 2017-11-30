namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv30 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonsPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ReviewPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LessonsPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "Course_Id" });
            DropColumn("dbo.LessonsPerCourses", "CourseId");
            DropColumn("dbo.ReviewPerCourses", "CourseId");
            DropColumn("dbo.UsersPerCourses", "CourseId");
            RenameColumn(table: "dbo.LessonsPerCourses", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.ReviewPerCourses", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.UsersPerCourses", name: "Course_Id", newName: "CourseId");
            DropPrimaryKey("dbo.Courses");
            AddColumn("dbo.LessonsPerCourses", "Order", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Icon", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Price", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.LessonsPerCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UsersPerCourses", "CourseId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Courses", "Id");
            CreateIndex("dbo.LessonsPerCourses", "CourseId");
            CreateIndex("dbo.UsersPerCourses", "CourseId");
            CreateIndex("dbo.UsersPerCourses", "UserId");
            CreateIndex("dbo.ReviewPerCourses", "CourseId");
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            AddForeignKey("dbo.LessonsPerCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReviewPerCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersPerCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.LessonsPerCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "CourseId" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "CourseId" });
            DropIndex("dbo.LessonsPerCourses", new[] { "CourseId" });
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.UsersPerCourses", "CourseId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UsersPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "CourseId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ReviewPerCourses", "Comment", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "CourseId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LessonsPerCourses", "Content", c => c.String());
            AlterColumn("dbo.LessonsPerCourses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Price", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "Icon", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.LessonsPerCourses", "Order");
            AddPrimaryKey("dbo.Courses", "Id");
            RenameColumn(table: "dbo.UsersPerCourses", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.ReviewPerCourses", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.LessonsPerCourses", name: "CourseId", newName: "Course_Id");
            AddColumn("dbo.UsersPerCourses", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.ReviewPerCourses", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.LessonsPerCourses", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.UsersPerCourses", "Course_Id");
            CreateIndex("dbo.UsersPerCourses", "UserId");
            CreateIndex("dbo.ReviewPerCourses", "Course_Id");
            CreateIndex("dbo.ReviewPerCourses", "UserId");
            CreateIndex("dbo.LessonsPerCourses", "Course_Id");
            AddForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UsersPerCourses", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.LessonsPerCourses", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
