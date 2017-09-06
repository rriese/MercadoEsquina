namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MercadoEsquina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        cpf = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        Client_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.Client_id)
                .Index(t => t.Client_id);
            
        }

        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Client_id", "dbo.Clients");
            DropIndex("dbo.Clients", new[] { "Client_id" });
            DropTable("dbo.Clients");
        }

        internal class Models
        {
            internal class ApplicationDbContext
            {
            }
        }
    }
}
