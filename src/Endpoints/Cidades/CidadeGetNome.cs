using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadeGetNome
{
    public static string Template => "/cidades/nome/{nome}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => (Func<string, ApplicationDbContext, IResult>)Action;

    public static IResult Action(string Nome, ApplicationDbContext context)
    {
        var cidade = context.cidades.Where(c => c.Nome == Nome).FirstOrDefault();
        

       // var response = new CidadeResponse { Nome = cidade.Nome, Estado = cidade.Estado };

        return Results.Ok(cidade);
    }
}
