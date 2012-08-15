namespace OpsCenter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Environments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Configurations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Environment = c.String(),
                        ConfigKey = c.String(),
                        Value = c.String(),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Configurations");
            DropTable("Environments");
        }
    }
}
