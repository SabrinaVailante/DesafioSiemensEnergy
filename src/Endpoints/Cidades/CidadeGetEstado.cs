using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadeGetEstado
{
    public static string Template => "/cidades/estado/{estado}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(string Estado, ApplicationDbContext context)
    {
        List<Cidade> cidades = context.cidades.Where(c => c.Estado == Estado).ToList();

        return Results.Ok(cidades);
    }
}
