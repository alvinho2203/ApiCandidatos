namespace ApiCandidatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatos",
                c => new
                {
                    CandidatoId = c.Int(nullable: false, identity: true),
                    Nome = c.String(maxLength: 100),
                    Email = c.String(maxLength: 150),
                    Telefone = c.String(maxLength: 40),
                    Vaga = c.String(maxLength: 40),
                    EnderecoId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);

            CreateTable(
                "dbo.Enderecos",
                c => new
                {
                    EnderecoId = c.Int(nullable: false, identity: true),
                    Local = c.String(maxLength: 150),
                    Cidade = c.String(maxLength: 100),
                    Estado = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.EnderecoId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Candidatos", new[] { "EnderecoId" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Candidatos");
        }
    }
}
