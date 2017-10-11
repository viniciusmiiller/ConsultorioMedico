namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoPacienteIsSub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacientes", "IsSub", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacientes", "IsSub");
        }
    }
}
