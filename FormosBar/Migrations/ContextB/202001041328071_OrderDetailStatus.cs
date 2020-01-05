namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetailStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetail", "Status");
        }
    }
}
