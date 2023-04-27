using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadePost
{
    public static string Template => "/cidades";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CidadeRequest cidadeRequest, ApplicationDbContext context)
    {
        var cidade = new Cidade
        {
            Nome = cidadeRequest.Nome,
            Estado = cidadeRequest.Estado,
            
        };
        context.cidades.Add(cidade);

        context.SaveChanges();

        return Results.Created($"/cidades/{cidade.Id}", cidade.Id);
    }
}
