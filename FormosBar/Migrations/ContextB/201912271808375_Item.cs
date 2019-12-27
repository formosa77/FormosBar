namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Category", c => c.String());
        }
    }
}
