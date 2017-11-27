namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ClientId", c => c.Byte(nullable: false));
        }
    }
}
