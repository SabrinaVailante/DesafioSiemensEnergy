using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClientePost
{
    public static string Template => "/clientes";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ClienteRequest clienteRequest, ApplicationDbContext context)
    {
        var cidade = context.cidades.Where(c => c.Id == clienteRequest.cidade).FirstOrDefault();
        

        var cliente = new Cliente
        {
            NomeCompleto = clienteRequest.NomeCompleto, 
            Sexo  = clienteRequest.Sexo,
            DataNascimento = clienteRequest.DataNascimento,
            Idade = clienteRequest.Idade, 
            Cidade = cidade,
            
            
        };
        context.clientes.Add(cliente);

        context.SaveChanges();

        return Results.Created($"/clientes/{cliente.Id}", cliente.Id);
    }
}
