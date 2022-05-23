using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Carros.Infra.Data.Migrations
{
    public partial class PrimeirosCarros : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO [dbo].[Carros] ([Name],[Descricao],[Modelo],[Ano],[Quilometragem],[Portas],[PotenciaMotor],[Placa],[Preco],[CambioId],[CombustivelId],[MarcaId],[DirecaoId])"+
                   "VALUES"+
                   "( 'Azera','Azera prata gls 3.3', 'GLS', 2019, 1000, 4, 3.3," +
                   " 'xpto123', 4500.00, 2, 1, 1, 1);");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM [dbo].[Carros]");
        }
    }
}
