namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populacao : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Pacientes(Nome) VALUES ('Melina Caregnato')");
            Sql("INSERT INTO Pacientes(Nome) VALUES ('Milena Joly')");
        }
        
        public override void Down()
        {
        }
    }
}
