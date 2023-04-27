using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadePut
{
    public static string Template => "/cidades/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int Id, CidadeRequest cidadeRequest, ApplicationDbContext context)
    {
        var cidade = context.cidades.Where(c => c.Id == Id).FirstOrDefault();
        cidade.Nome = cidadeRequest.Nome;
        cidade.Estado = cidadeRequest.Estado;

        context.SaveChanges();

        return Results.Ok();
    }
}
