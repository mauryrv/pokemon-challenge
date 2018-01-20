namespace pokemon_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abilitie = c.String(),
                        descriptions = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.PokemonInfoAbilities",
                c => new
                    {
                        PokemonInfo_Id = c.Int(nullable: false),
                        Abilities_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonInfo_Id, t.Abilities_Id })
                .ForeignKey("dbo.PokemonInfoes", t => t.PokemonInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Abilities", t => t.Abilities_Id, cascadeDelete: true)
                .Index(t => t.PokemonInfo_Id)
                .Index(t => t.Abilities_Id);
            
            CreateTable(
                "dbo.MovimentsPokemonInfoes",
                c => new
                    {
                        Moviments_Id = c.Int(nullable: false),
                        PokemonInfo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Moviments_Id, t.PokemonInfo_Id })
                .ForeignKey("dbo.Moviments", t => t.Moviments_Id, cascadeDelete: true)
                .ForeignKey("dbo.PokemonInfoes", t => t.PokemonInfo_Id, cascadeDelete: true)
                .Index(t => t.Moviments_Id)
                .Index(t => t.PokemonInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimentsPokemonInfoes", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropForeignKey("dbo.MovimentsPokemonInfoes", "Moviments_Id", "dbo.Moviments");
            DropForeignKey("dbo.PokemonInfoAbilities", "Abilities_Id", "dbo.Abilities");
            DropForeignKey("dbo.PokemonInfoAbilities", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropIndex("dbo.MovimentsPokemonInfoes", new[] { "PokemonInfo_Id" });
            DropIndex("dbo.MovimentsPokemonInfoes", new[] { "Moviments_Id" });
            DropIndex("dbo.PokemonInfoAbilities", new[] { "Abilities_Id" });
            DropIndex("dbo.PokemonInfoAbilities", new[] { "PokemonInfo_Id" });
            DropTable("dbo.MovimentsPokemonInfoes");
            DropTable("dbo.PokemonInfoAbilities");
            DropTable("dbo.Moviments");
            DropTable("dbo.PokemonInfoes");
            DropTable("dbo.Abilities");
        }
    }
}
