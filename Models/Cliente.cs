using System.ComponentModel.DataAnnotations;

namespace Final_Project_2._1.Models
{
    public class Cliente
    {
        // define a propriedade Id como
        // PRIMARY KEY na base de dados
        [Key]
        public int id { get; set; }

        public string? nome { get; set; }
        public string? morada { get; set; }
        public string? codPostal { get; set; }
        public string? localidade { get; set; }
        public int telefone { get; set; }
        public string? email { get; set; }
        public int nif { get; set; }
        public float saldoDisp { get; set; }
        public DateTime validade { get; set; }

    }
}
