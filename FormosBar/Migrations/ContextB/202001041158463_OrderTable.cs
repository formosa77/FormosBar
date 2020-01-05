namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Status");
        }
    }
}
