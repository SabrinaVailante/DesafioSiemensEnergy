using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadeGetAll
{
    public static string Template => "/cidades";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action( ApplicationDbContext context)
    {
        var cidade = context.cidades.ToList();
        var response = cidade.Select(c => new CidadeResponse { Nome = c.Nome, Estado = c.Estado });
        

        context.SaveChanges();

        return Results.Ok(cidade);
    }
}
