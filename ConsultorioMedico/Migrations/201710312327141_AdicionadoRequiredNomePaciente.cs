namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoRequiredNomePaciente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacientes", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacientes", "Nome", c => c.String());
        }
    }
}
