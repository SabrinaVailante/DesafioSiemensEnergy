using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClienteGetAll
{
    public static string Template => "/clientes";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action( ApplicationDbContext context)
    {
        var cliente = context.clientes.ToList();
        return Results.NotFound(cliente);
        var response = cliente.Select(c => new ClienteResponse { NomeCompleto = c.NomeCompleto, Sexo = c.Sexo, DataNascimento =  c.DataNascimento, Idade = c.Idade, cidade = c.Cidade  });
        

        context.SaveChanges();

        return Results.Ok(cliente);
    }
}
