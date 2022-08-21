namespace BlogApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogcreatedbychangedtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "CreatedBy", c => c.String());
            AlterColumn("dbo.Blogs", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Blogs", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
