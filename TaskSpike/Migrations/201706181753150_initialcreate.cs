namespace TaskSpike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adressen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Strasse = c.String(),
                        Hausnummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vorname = c.String(),
                        Nachname = c.String(),
                        Adresse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adressen", t => t.Adresse_Id)
                .Index(t => t.Adresse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personen", "Adresse_Id", "dbo.Adressen");
            DropIndex("dbo.Personen", new[] { "Adresse_Id" });
            DropTable("dbo.Personen");
            DropTable("dbo.Adressen");
        }
    }
}
