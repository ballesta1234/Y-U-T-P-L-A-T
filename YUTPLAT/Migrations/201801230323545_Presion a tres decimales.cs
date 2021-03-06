namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Presionatresdecimales : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meta", "Valor1", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Meta", "Valor2", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Medicion", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medicion", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Meta", "Valor2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Meta", "Valor1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
