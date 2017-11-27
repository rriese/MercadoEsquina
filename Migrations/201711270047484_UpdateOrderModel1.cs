namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            AlterColumn("dbo.Orders", "Client_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Client_Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            AlterColumn("dbo.Orders", "Client_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Client_Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
