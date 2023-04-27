using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClienteGetNome
{
    public static string Template => "/clientes/nome/{nome}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => (Func<string, ApplicationDbContext, IResult>)Action;

    public static IResult Action(string Nome, ApplicationDbContext context)
    {
        var cliente = context.clientes.Include(c => c.Cidade).Where(c => c.NomeCompleto == Nome).FirstOrDefault();

        return Results.Ok(cliente);
    }
}
