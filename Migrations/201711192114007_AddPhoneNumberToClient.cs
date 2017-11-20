namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "PhoneNumber");
        }
    }
}
