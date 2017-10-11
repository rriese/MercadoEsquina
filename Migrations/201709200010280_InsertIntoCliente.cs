namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoCliente : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Clients(name, cpf, birthDate) VALUES ('Matheus Lixo', '6565655', '09-19-17')");
        }
        
        public override void Down()
        {
        }
    }
}
