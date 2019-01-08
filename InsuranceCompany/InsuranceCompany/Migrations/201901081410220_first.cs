namespace InsuranceCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        PassportNumber = c.Int(nullable: false),
                        PassportSeria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        DirectoryId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Directories", t => t.DirectoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ClientId)
                .Index(t => t.DirectoryId);
            
            CreateTable(
                "dbo.Directories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DamageAmount = c.Int(nullable: false),
                        InsuranceFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsuranceCases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserRole = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Contracts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.InsuranceCases", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "DirectoryId", "dbo.Directories");
            DropForeignKey("dbo.Contracts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Salaries", new[] { "UserId" });
            DropIndex("dbo.Comissions", new[] { "UserId" });
            DropIndex("dbo.InsuranceCases", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "DirectoryId" });
            DropIndex("dbo.Contracts", new[] { "ClientId" });
            DropIndex("dbo.Contracts", new[] { "UserId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Comissions");
            DropTable("dbo.Users");
            DropTable("dbo.InsuranceCases");
            DropTable("dbo.Directories");
            DropTable("dbo.Contracts");
            DropTable("dbo.Clients");
        }
    }
}
