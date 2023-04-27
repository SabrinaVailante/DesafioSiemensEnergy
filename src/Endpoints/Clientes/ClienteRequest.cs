using DesafioSiemens.Dominio.Relacao;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClienteRequest
{
    public string NomeCompleto { get; set; }
    public string Sexo { get; set; }
    public string DataNascimento { get; set; }
    public int Idade { get; set; }
    public int cidade { get; set; }
}