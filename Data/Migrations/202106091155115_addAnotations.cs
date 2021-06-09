namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Faculties", "Dean", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Faculties", "City", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Specialities", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Specialities", "InspectorName", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Specialities", "InspectorName", c => c.String());
            AlterColumn("dbo.Specialities", "Name", c => c.String());
            AlterColumn("dbo.Faculties", "City", c => c.String());
            AlterColumn("dbo.Faculties", "Dean", c => c.String());
            AlterColumn("dbo.Faculties", "Name", c => c.String());
        }
    }
}
