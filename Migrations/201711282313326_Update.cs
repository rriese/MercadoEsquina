namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "SupplierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SupplierId", c => c.Byte(nullable: false));
        }
    }
}
