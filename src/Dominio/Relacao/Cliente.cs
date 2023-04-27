using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSiemens.Dominio.Relacao
{
    public class Cliente
    {       

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public int Idade { get; set; }

        //[ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
        
           
    }
}
