namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime());
        }
    }
}
