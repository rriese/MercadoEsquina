namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Function = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
