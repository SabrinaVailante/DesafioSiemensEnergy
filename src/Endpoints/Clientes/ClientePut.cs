using DesafioSiemens.Dominio.Relacao;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClientePut
{
    public static string Template => "/clientes/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int Id, ClienteRequest clienteRequest, ApplicationDbContext context)
    {
        var cliente = context.clientes.Where(c => c.Id == Id).FirstOrDefault();
        cliente.NomeCompleto = clienteRequest.NomeCompleto;
        cliente.Sexo = clienteRequest.Sexo;
        cliente.DataNascimento = clienteRequest.DataNascimento;
        cliente.Idade = clienteRequest.Idade;
        

        context.SaveChanges();

        return Results.Ok();
    }
}
