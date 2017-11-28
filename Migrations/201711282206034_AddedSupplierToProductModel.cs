namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplierToProductModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SupplierId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "Supplier_Id", c => c.Int());
            CreateIndex("dbo.Products", "Supplier_Id");
            AddForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "Supplier_Id" });
            DropColumn("dbo.Products", "Supplier_Id");
            DropColumn("dbo.Products", "SupplierId");
        }
    }
}
