namespace YUTPLAT.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Areas2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Area", "FechaCreacion", c => c.DateTime());
            AlterColumn("dbo.Area", "FechaUltimaModificacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Area", "FechaUltimaModificacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Area", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
