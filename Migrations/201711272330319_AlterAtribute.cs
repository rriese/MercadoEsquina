namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterAtribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Suppliers", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Endereco", c => c.String(nullable: false));
            DropColumn("dbo.Suppliers", "Address");
        }
    }
}
