namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agragarfechavalidezindicador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicador", "FechaValidez", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indicador", "FechaValidez");
        }
    }
}
