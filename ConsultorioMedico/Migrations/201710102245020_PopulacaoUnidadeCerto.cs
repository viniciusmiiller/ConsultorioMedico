namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulacaoUnidadeCerto : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Unidades(Nome) VALUES ('Unidade de Medida')");
            Sql("INSERT INTO Unidades(Nome) VALUES ('U.B.S Amizade')");
        }
        
        public override void Down()
        {
        }
    }
}
