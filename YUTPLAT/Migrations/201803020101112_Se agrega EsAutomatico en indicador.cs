namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeagregaEsAutomaticoenindicador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicador", "EsAutomatico", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indicador", "EsAutomatico");
        }
    }
}
