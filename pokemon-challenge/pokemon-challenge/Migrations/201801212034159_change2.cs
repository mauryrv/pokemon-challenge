namespace pokemon_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PokemonInfoAbilities", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropForeignKey("dbo.PokemonInfoAbilities", "Abilities_Id", "dbo.Abilities");
            DropForeignKey("dbo.MovimentsPokemonInfoes", "Moviments_Id", "dbo.Moviments");
            DropForeignKey("dbo.MovimentsPokemonInfoes", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropIndex("dbo.PokemonInfoAbilities", new[] { "PokemonInfo_Id" });
            DropIndex("dbo.PokemonInfoAbilities", new[] { "Abilities_Id" });
            DropIndex("dbo.MovimentsPokemonInfoes", new[] { "Moviments_Id" });
            DropIndex("dbo.MovimentsPokemonInfoes", new[] { "PokemonInfo_Id" });
            AddColumn("dbo.Abilities", "PokemonInfo_Id", c => c.Int());
            AddColumn("dbo.Moviments", "PokemonInfo_Id", c => c.Int());
            CreateIndex("dbo.Abilities", "PokemonInfo_Id");
            CreateIndex("dbo.Moviments", "PokemonInfo_Id");
            AddForeignKey("dbo.Abilities", "PokemonInfo_Id", "dbo.PokemonInfoes", "Id");
            AddForeignKey("dbo.Moviments", "PokemonInfo_Id", "dbo.PokemonInfoes", "Id");
            DropTable("dbo.PokemonInfoAbilities");
            DropTable("dbo.MovimentsPokemonInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovimentsPokemonInfoes",
                c => new
                    {
                        Moviments_Id = c.Int(nullable: false),
                        PokemonInfo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Moviments_Id, t.PokemonInfo_Id });
            
            CreateTable(
                "dbo.PokemonInfoAbilities",
                c => new
                    {
                        PokemonInfo_Id = c.Int(nullable: false),
                        Abilities_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonInfo_Id, t.Abilities_Id });
            
            DropForeignKey("dbo.Moviments", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropForeignKey("dbo.Abilities", "PokemonInfo_Id", "dbo.PokemonInfoes");
            DropIndex("dbo.Moviments", new[] { "PokemonInfo_Id" });
            DropIndex("dbo.Abilities", new[] { "PokemonInfo_Id" });
            DropColumn("dbo.Moviments", "PokemonInfo_Id");
            DropColumn("dbo.Abilities", "PokemonInfo_Id");
            CreateIndex("dbo.MovimentsPokemonInfoes", "PokemonInfo_Id");
            CreateIndex("dbo.MovimentsPokemonInfoes", "Moviments_Id");
            CreateIndex("dbo.PokemonInfoAbilities", "Abilities_Id");
            CreateIndex("dbo.PokemonInfoAbilities", "PokemonInfo_Id");
            AddForeignKey("dbo.MovimentsPokemonInfoes", "PokemonInfo_Id", "dbo.PokemonInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovimentsPokemonInfoes", "Moviments_Id", "dbo.Moviments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PokemonInfoAbilities", "Abilities_Id", "dbo.Abilities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PokemonInfoAbilities", "PokemonInfo_Id", "dbo.PokemonInfoes", "Id", cascadeDelete: true);
        }
    }
}
