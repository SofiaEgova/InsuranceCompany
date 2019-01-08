namespace InsuranceCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addToDirectory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Directories", "InsuranceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directories", "InsuranceType");
        }
    }
}
