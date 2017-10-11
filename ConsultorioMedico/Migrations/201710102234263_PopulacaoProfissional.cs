namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulacaoProfissional : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Profissionals(Nome) VALUES ('Maria Luiza')");
            Sql("INSERT INTO Profissionals(Nome) VALUES ('Vinícius Miiller')");
        }
        
        public override void Down()
        {
        }
    }
}
