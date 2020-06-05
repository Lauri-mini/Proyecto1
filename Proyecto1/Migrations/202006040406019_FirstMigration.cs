namespace Proyecto1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.users", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.users", new[] { "UserId" });
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "ApM", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "ApP", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Direccion", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Celular", c => c.String(maxLength: 20));
            DropTable("dbo.users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ApM = c.String(nullable: false, maxLength: 50),
                        ApP = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        Celular = c.String(nullable: false, maxLength: 20),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Visitors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Visitors", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Celular");
            DropColumn("dbo.AspNetUsers", "Direccion");
            DropColumn("dbo.AspNetUsers", "ApP");
            DropColumn("dbo.AspNetUsers", "ApM");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropTable("dbo.Visitors");
            CreateIndex("dbo.users", "UserId");
            AddForeignKey("dbo.users", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
