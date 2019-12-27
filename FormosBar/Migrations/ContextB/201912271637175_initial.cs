namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Name = c.String(nullable: false, maxLength: 160),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        OnShelf = c.Boolean(nullable: false),
                        DefaultImageURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Item");
        }
    }
}
