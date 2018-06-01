namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seagreganoaplicaenlamedicion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicion", "NoAplica", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicion", "NoAplica");
        }
    }
}
