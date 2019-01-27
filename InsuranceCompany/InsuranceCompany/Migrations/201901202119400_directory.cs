namespace InsuranceCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class directory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Directories", "InsuranceTerm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directories", "InsuranceTerm");
        }
    }
}
