using DesafioSiemens.Dominio.Relacao;

namespace DesafioSiemens.Endpoints.Clientes;

public class ClienteResponse
{
    public string NomeCompleto { get; set; }
    public string Sexo { get; set; }
    public string DataNascimento { get; set; }
    public int Idade { get; set; }
    public string cidade { get; set; }
}