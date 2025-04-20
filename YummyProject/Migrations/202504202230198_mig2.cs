namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Icon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Icon", c => c.String());
            AlterColumn("dbo.Services", "Description", c => c.String());
            AlterColumn("dbo.Services", "Title", c => c.String());
        }
    }
}
