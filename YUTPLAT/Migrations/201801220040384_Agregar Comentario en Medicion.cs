namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarComentarioenMedicion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicion", "Comentario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicion", "Comentario");
        }
    }
}
