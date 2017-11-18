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
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.LessonsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
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
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Course_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ReviewPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.LessonsPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UserId" });
            DropIndex("dbo.LessonsPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "Credit");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.UsersPerCourses");
            DropTable("dbo.ReviewPerCourses");
            DropTable("dbo.Incomes");
            DropTable("dbo.LessonsPerCourses");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
