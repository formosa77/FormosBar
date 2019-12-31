namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAdd1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "Complete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Complete", c => c.Boolean(nullable: false));
        }
    }
}
