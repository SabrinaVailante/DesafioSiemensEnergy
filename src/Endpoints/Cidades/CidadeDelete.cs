using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Cidades;

public class CidadeDelete
{
    public static string Template => "/cidades/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FormRoute] int Id, ApplicationDbContext context)
    {
        var cidade = context.cidades.Where( c => c.Id == Id ).FirstOrDefault(); 
        context.cidades.Remove( cidade );
        

        

        context.SaveChanges();

        return Results.Ok();
    }
}
