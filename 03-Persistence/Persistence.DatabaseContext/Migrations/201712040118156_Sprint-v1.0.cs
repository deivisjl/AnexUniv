namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseLessonsLearnedPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonsPerCourses", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LessonId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LessonsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Status = c.Int(nullable: false),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "LessonId", "dbo.LessonsPerCourses");
            DropForeignKey("dbo.LessonsPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "CourseId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.LessonsPerCourses", new[] { "CourseId" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "UserId" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "LessonId" });
            DropColumn("dbo.AspNetUsers", "Credit");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.UsersPerCourses");
            DropTable("dbo.ReviewPerCourses");
            DropTable("dbo.Incomes");
            DropTable("dbo.Courses");
            DropTable("dbo.LessonsPerCourses");
            DropTable("dbo.CourseLessonsLearnedPerStudents");
            DropTable("dbo.Categories");
        }
    }
}
