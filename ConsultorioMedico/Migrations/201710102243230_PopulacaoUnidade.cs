namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulacaoUnidade : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Profissionals(Nome) VALUES ('Unidade de Medida')");
            Sql("INSERT INTO Profissionals(Nome) VALUES ('U.B.S Amizade')");
        }
        
        public override void Down()
        {
        }
    }
}
