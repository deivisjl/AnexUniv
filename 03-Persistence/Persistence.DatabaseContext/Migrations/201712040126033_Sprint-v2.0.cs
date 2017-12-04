namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv20 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Category_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.CourseLessonsLearnedPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CourseLessonsLearnedPerStudent_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.LessonsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LessonsPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Course_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityID = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Incomes_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ReviewPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ReviewPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UsersPerCourses_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Categories", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.CourseLessonsLearnedPerStudents", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LessonsPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.LessonsPerCourses", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.LessonsPerCourses", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LessonsPerCourses", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.LessonsPerCourses", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LessonsPerCourses", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.LessonsPerCourses", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Courses", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Courses", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Courses", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Incomes", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Incomes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Incomes", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Incomes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Incomes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Incomes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Incomes", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ReviewPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReviewPerCourses", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ReviewPerCourses", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ReviewPerCourses", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ReviewPerCourses", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ReviewPerCourses", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ReviewPerCourses", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.UsersPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersPerCourses", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.UsersPerCourses", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.UsersPerCourses", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.UsersPerCourses", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.UsersPerCourses", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.UsersPerCourses", "DeletedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "CreatedBy");
            CreateIndex("dbo.Categories", "UpdatedBy");
            CreateIndex("dbo.Categories", "DeletedBy");
            CreateIndex("dbo.CourseLessonsLearnedPerStudents", "CreatedBy");
            CreateIndex("dbo.CourseLessonsLearnedPerStudents", "UpdatedBy");
            CreateIndex("dbo.CourseLessonsLearnedPerStudents", "DeletedBy");
            CreateIndex("dbo.LessonsPerCourses", "CreatedBy");
            CreateIndex("dbo.LessonsPerCourses", "UpdatedBy");
            CreateIndex("dbo.LessonsPerCourses", "DeletedBy");
            CreateIndex("dbo.Courses", "CreatedBy");
            CreateIndex("dbo.Courses", "UpdatedBy");
            CreateIndex("dbo.Courses", "DeletedBy");
            CreateIndex("dbo.Incomes", "CreatedBy");
            CreateIndex("dbo.Incomes", "UpdatedBy");
            CreateIndex("dbo.Incomes", "DeletedBy");
            CreateIndex("dbo.ReviewPerCourses", "CreatedBy");
            CreateIndex("dbo.ReviewPerCourses", "UpdatedBy");
            CreateIndex("dbo.ReviewPerCourses", "DeletedBy");
            CreateIndex("dbo.UsersPerCourses", "CreatedBy");
            CreateIndex("dbo.UsersPerCourses", "UpdatedBy");
            CreateIndex("dbo.UsersPerCourses", "DeletedBy");
            AddForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Categories", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Categories", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CourseLessonsLearnedPerStudents", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CourseLessonsLearnedPerStudents", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LessonsPerCourses", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LessonsPerCourses", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LessonsPerCourses", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CourseLessonsLearnedPerStudents", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Incomes", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Incomes", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Incomes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReviewPerCourses", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UsersPerCourses", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UsersPerCourses", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UsersPerCourses", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonsLearnedPerStudents", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.UsersPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.UsersPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.UsersPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.ReviewPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.ReviewPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.ReviewPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.Incomes", new[] { "DeletedBy" });
            DropIndex("dbo.Incomes", new[] { "UpdatedBy" });
            DropIndex("dbo.Incomes", new[] { "CreatedBy" });
            DropIndex("dbo.Courses", new[] { "DeletedBy" });
            DropIndex("dbo.Courses", new[] { "UpdatedBy" });
            DropIndex("dbo.Courses", new[] { "CreatedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "DeletedBy" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "UpdatedBy" });
            DropIndex("dbo.CourseLessonsLearnedPerStudents", new[] { "CreatedBy" });
            DropIndex("dbo.Categories", new[] { "DeletedBy" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropColumn("dbo.UsersPerCourses", "DeletedBy");
            DropColumn("dbo.UsersPerCourses", "DeletedAt");
            DropColumn("dbo.UsersPerCourses", "UpdatedBy");
            DropColumn("dbo.UsersPerCourses", "UpdatedAt");
            DropColumn("dbo.UsersPerCourses", "CreatedBy");
            DropColumn("dbo.UsersPerCourses", "CreatedAt");
            DropColumn("dbo.UsersPerCourses", "Deleted");
            DropColumn("dbo.ReviewPerCourses", "DeletedBy");
            DropColumn("dbo.ReviewPerCourses", "DeletedAt");
            DropColumn("dbo.ReviewPerCourses", "UpdatedBy");
            DropColumn("dbo.ReviewPerCourses", "UpdatedAt");
            DropColumn("dbo.ReviewPerCourses", "CreatedBy");
            DropColumn("dbo.ReviewPerCourses", "CreatedAt");
            DropColumn("dbo.ReviewPerCourses", "Deleted");
            DropColumn("dbo.Incomes", "DeletedBy");
            DropColumn("dbo.Incomes", "DeletedAt");
            DropColumn("dbo.Incomes", "UpdatedBy");
            DropColumn("dbo.Incomes", "UpdatedAt");
            DropColumn("dbo.Incomes", "CreatedBy");
            DropColumn("dbo.Incomes", "CreatedAt");
            DropColumn("dbo.Incomes", "Deleted");
            DropColumn("dbo.Courses", "DeletedBy");
            DropColumn("dbo.Courses", "DeletedAt");
            DropColumn("dbo.Courses", "UpdatedBy");
            DropColumn("dbo.Courses", "UpdatedAt");
            DropColumn("dbo.Courses", "CreatedBy");
            DropColumn("dbo.Courses", "CreatedAt");
            DropColumn("dbo.Courses", "Deleted");
            DropColumn("dbo.LessonsPerCourses", "DeletedBy");
            DropColumn("dbo.LessonsPerCourses", "DeletedAt");
            DropColumn("dbo.LessonsPerCourses", "UpdatedBy");
            DropColumn("dbo.LessonsPerCourses", "UpdatedAt");
            DropColumn("dbo.LessonsPerCourses", "CreatedBy");
            DropColumn("dbo.LessonsPerCourses", "CreatedAt");
            DropColumn("dbo.LessonsPerCourses", "Deleted");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "DeletedBy");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "DeletedAt");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "UpdatedBy");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "UpdatedAt");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "CreatedBy");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "CreatedAt");
            DropColumn("dbo.CourseLessonsLearnedPerStudents", "Deleted");
            DropColumn("dbo.Categories", "DeletedBy");
            DropColumn("dbo.Categories", "DeletedAt");
            DropColumn("dbo.Categories", "UpdatedBy");
            DropColumn("dbo.Categories", "UpdatedAt");
            DropColumn("dbo.Categories", "CreatedBy");
            DropColumn("dbo.Categories", "CreatedAt");
            DropColumn("dbo.Categories", "Deleted");
            AlterTableAnnotations(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UsersPerCourses_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ReviewPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ReviewPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityID = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Incomes_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Course_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.LessonsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LessonsPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.CourseLessonsLearnedPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CourseLessonsLearnedPerStudent_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Category_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
