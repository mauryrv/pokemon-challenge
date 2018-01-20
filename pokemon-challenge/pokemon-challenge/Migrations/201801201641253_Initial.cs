namespace pokemon_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        habilities = c.String(),
                        descriptions = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PokemonHabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PokemonInfoId = c.Int(nullable: false),
                        HabilitiesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PokemonInfoes", t => t.PokemonInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Habilities", t => t.HabilitiesId, cascadeDelete: true)
                .Index(t => t.PokemonInfoId)
                .Index(t => t.HabilitiesId);
            
            CreateTable(
                "dbo.PokemonInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        baseExperience = c.Decimal(nullable: false, precision: 18, scale: 2),
                        speed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        defense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        attack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moviments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        moviment = c.String(),
                        description = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PokemonMoviments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PokemonInfoId = c.Int(nullable: false),
                        MovimentsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PokemonInfoes", t => t.PokemonInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Moviments", t => t.MovimentsId, cascadeDelete: true)
                .Index(t => t.PokemonInfoId)
                .Index(t => t.MovimentsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PokemonMoviments", "MovimentsId", "dbo.Moviments");
            DropForeignKey("dbo.PokemonMoviments", "PokemonInfoId", "dbo.PokemonInfoes");
            DropForeignKey("dbo.PokemonHabilities", "HabilitiesId", "dbo.Habilities");
            DropForeignKey("dbo.PokemonHabilities", "PokemonInfoId", "dbo.PokemonInfoes");
            DropIndex("dbo.PokemonMoviments", new[] { "MovimentsId" });
            DropIndex("dbo.PokemonMoviments", new[] { "PokemonInfoId" });
            DropIndex("dbo.PokemonHabilities", new[] { "HabilitiesId" });
            DropIndex("dbo.PokemonHabilities", new[] { "PokemonInfoId" });
            DropTable("dbo.PokemonMoviments");
            DropTable("dbo.Moviments");
            DropTable("dbo.PokemonInfoes");
            DropTable("dbo.PokemonHabilities");
            DropTable("dbo.Habilities");
        }
    }
}
