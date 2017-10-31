namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoRequiredNosModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agenda", "DiaSemana", c => c.String(nullable: false));
            AlterColumn("dbo.Profissionals", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Unidades", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Unidades", "Nome", c => c.String());
            AlterColumn("dbo.Profissionals", "Nome", c => c.String());
            AlterColumn("dbo.Agenda", "DiaSemana", c => c.String());
        }
    }
}
