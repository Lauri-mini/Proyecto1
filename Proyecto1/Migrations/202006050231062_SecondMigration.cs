namespace Proyecto1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.biodiversities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Especie = c.String(nullable: false, maxLength: 50),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sanctuaries",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Ubicacion = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.biodiversities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.visit_shrine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        santuario_Id = c.Int(),
                        visita_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.sanctuaries", t => t.santuario_Id)
                .ForeignKey("dbo.visits", t => t.visita_Id)
                .Index(t => t.santuario_Id)
                .Index(t => t.visita_Id);
            
            CreateTable(
                "dbo.visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Cantidad = c.String(nullable: false, maxLength: 50),
                        FechaHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.visit_shrine", "visita_Id", "dbo.visits");
            DropForeignKey("dbo.visit_shrine", "santuario_Id", "dbo.sanctuaries");
            DropForeignKey("dbo.sanctuaries", "Id", "dbo.biodiversities");
            DropIndex("dbo.visit_shrine", new[] { "visita_Id" });
            DropIndex("dbo.visit_shrine", new[] { "santuario_Id" });
            DropIndex("dbo.sanctuaries", new[] { "Id" });
            DropTable("dbo.visits");
            DropTable("dbo.visit_shrine");
            DropTable("dbo.sanctuaries");
            DropTable("dbo.biodiversities");
        }
    }
}
