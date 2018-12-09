namespace InsuranceCompanyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Commission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AgentId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Passport = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.InsuranceCases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agents", "UserId", "dbo.Users");
            DropForeignKey("dbo.InsuranceCases", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Accountants", "UserId", "dbo.Users");
            DropIndex("dbo.InsuranceCases", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "AgentId" });
            DropIndex("dbo.Agents", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropIndex("dbo.Accountants", new[] { "UserId" });
            DropTable("dbo.InsuranceCases");
            DropTable("dbo.Contracts");
            DropTable("dbo.Clients");
            DropTable("dbo.Agents");
            DropTable("dbo.Admins");
            DropTable("dbo.Users");
            DropTable("dbo.Accountants");
        }
    }
}
