namespace YUTPLAT.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Areas1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Area");
            AddColumn("dbo.Area", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Area", "Descripcion", c => c.String());
            AddColumn("dbo.Area", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Area", "UltimoUsuarioModifico", c => c.String());
            AddColumn("dbo.Area", "FechaUltimaModificacion", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Area", "Id");
            DropColumn("dbo.Area", "AreaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Area", "AreaID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Area");
            DropColumn("dbo.Area", "FechaUltimaModificacion");
            DropColumn("dbo.Area", "UltimoUsuarioModifico");
            DropColumn("dbo.Area", "FechaCreacion");
            DropColumn("dbo.Area", "Descripcion");
            DropColumn("dbo.Area", "Id");
            AddPrimaryKey("dbo.Area", "AreaID");
        }
    }
}
