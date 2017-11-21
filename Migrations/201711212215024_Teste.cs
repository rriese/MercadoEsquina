namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            AlterColumn("dbo.Orders", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            AlterColumn("dbo.Orders", "Employee_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
