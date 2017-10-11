namespace ConsultorioMedico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoModelAgenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "Profissional_Id", c => c.Int());
            CreateIndex("dbo.Agenda", "Profissional_Id");
            AddForeignKey("dbo.Agenda", "Profissional_Id", "dbo.Profissionals", "Id");
            DropColumn("dbo.Agenda", "Profissional");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "Profissional", c => c.String());
            DropForeignKey("dbo.Agenda", "Profissional_Id", "dbo.Profissionals");
            DropIndex("dbo.Agenda", new[] { "Profissional_Id" });
            DropColumn("dbo.Agenda", "Profissional_Id");
        }
    }
}
