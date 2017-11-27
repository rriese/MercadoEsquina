namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelAndAddSupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Suppliers");
            CreateIndex("dbo.Orders", "Client_Id");
            CreateIndex("dbo.OrderItems", "Product_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
