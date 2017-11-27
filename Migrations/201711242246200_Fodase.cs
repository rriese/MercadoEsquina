namespace MercadoEsquina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fodase : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9daa14a9-f8c8-4721-8670-2017cf499ae6', N'rafinhariese@gmail.com', 0, N'AMw2OT4deFE32tJmNofwZFHtyp8tX0fwsd5cpEJlcm50OoszWLw/uzJ8feZe2ZEZ1A==', N'a0792714-be02-4bd9-802e-fa92f8cd6f24', NULL, 0, 0, NULL, 1, 0, N'rafinhariese@gmail.com')
");
        }
        
        public override void Down()
        {
        }
    }
}
