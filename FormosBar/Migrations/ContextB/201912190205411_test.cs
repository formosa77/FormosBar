namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Description", c => c.String());
            AddColumn("dbo.Item", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Description");
            DropColumn("dbo.Item", "Price");
        }
    }
}
