using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClienteDelete
{
    public static string Template => "/clientes/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FormRoute] int Id, ApplicationDbContext context)
    {
        var cliente = context.clientes.Where( c => c.Id == Id ).FirstOrDefault(); 
        context.clientes.Remove( cliente );
        

        

        context.SaveChanges();

        return Results.Ok();
    }
}
