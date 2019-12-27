namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Item", "ItemCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "ItemCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Item", "Category");
        }
    }
}
