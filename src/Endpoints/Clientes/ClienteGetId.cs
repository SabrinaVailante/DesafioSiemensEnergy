using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioSiemens.Endpoints.Clientes;


public class ClienteGetId
{
    public static string Template => "/clientes/id/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => (Func<int, ApplicationDbContext, IResult>)Action;

    public static IResult Action(int Id, ApplicationDbContext context)
    {
        var cliente = context.clientes.Include(c => c.Cidade).Where(c => c.Id == Id).FirstOrDefault();

        return Results.Ok(cliente);
    }
}
