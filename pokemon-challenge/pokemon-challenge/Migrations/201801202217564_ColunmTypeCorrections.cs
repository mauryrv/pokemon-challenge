namespace pokemon_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColunmTypeCorrections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "description", c => c.String());
            AlterColumn("dbo.Moviments", "description", c => c.String());
            DropColumn("dbo.Abilities", "descriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abilities", "descriptions", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Moviments", "description", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Abilities", "description");
        }
    }
}
