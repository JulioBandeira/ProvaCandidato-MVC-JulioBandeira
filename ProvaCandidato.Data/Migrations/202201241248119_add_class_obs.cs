namespace ProvaCandidato.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_class_obs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteObservacao",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        texto = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteObservacao", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.ClienteObservacao", new[] { "ClienteId" });
            DropTable("dbo.ClienteObservacao");
        }
    }
}
