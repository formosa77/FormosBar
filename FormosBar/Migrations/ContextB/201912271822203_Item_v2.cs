namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ItemCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Item", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Item", "ItemCategory");
        }
    }
}
