namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeySupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "Supplier_Id" });
            DropColumn("dbo.Products", "SupplierId");
            RenameColumn(table: "dbo.Products", name: "Supplier_Id", newName: "SupplierId");
            AlterColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            AlterColumn("dbo.Products", "SupplierId", c => c.Int());
            AlterColumn("dbo.Products", "SupplierId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Products", name: "SupplierId", newName: "Supplier_Id");
            AddColumn("dbo.Products", "SupplierId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Products", "Supplier_Id");
            AddForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
