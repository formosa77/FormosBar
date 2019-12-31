namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Complete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Complete");
        }
    }
}
