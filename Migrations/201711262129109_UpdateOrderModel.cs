namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropColumn("dbo.Orders", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Employee_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
