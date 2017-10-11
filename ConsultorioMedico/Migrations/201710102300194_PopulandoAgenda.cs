namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulandoAgenda : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Agenda(diaSemana, Vagas, Profissional_Id) VALUES ('Segunda', 2, 1)");
            Sql("INSERT INTO Agenda(diaSemana, Vagas, Profissional_Id) VALUES ('Terça', 3, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
