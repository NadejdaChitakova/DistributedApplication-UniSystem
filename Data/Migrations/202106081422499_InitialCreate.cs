namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Students", new[] { "SpecialityId" });
            AlterColumn("dbo.Students", "SpecialityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SpecialityId");
            AddForeignKey("dbo.Students", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Students", new[] { "SpecialityId" });
            AlterColumn("dbo.Students", "SpecialityId", c => c.Int());
            CreateIndex("dbo.Students", "SpecialityId");
            AddForeignKey("dbo.Students", "SpecialityId", "dbo.Specialities", "Id");
        }
    }
}
