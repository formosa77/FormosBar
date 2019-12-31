namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemImgAlt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ImageAlt", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "DefaultImageURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "DefaultImageURL", c => c.String());
            DropColumn("dbo.Item", "ImageAlt");
        }
    }
}
