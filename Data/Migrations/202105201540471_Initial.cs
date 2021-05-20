namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dean = c.String(),
                        City = c.String(),
                        Profit = c.Double(nullable: false),
                        CountEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountSubject = c.Byte(nullable: false),
                        Price = c.Double(nullable: false),
                        InspectorName = c.String(),
                        Duration = c.Byte(nullable: false),
                        FacultyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EGN = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        SpecialityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Specialities", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "SpecialityId" });
            DropIndex("dbo.Specialities", new[] { "FacultyId" });
            DropTable("dbo.Students");
            DropTable("dbo.Specialities");
            DropTable("dbo.Faculties");
        }
    }
}
