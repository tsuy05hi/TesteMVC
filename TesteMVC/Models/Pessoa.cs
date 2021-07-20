using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMVC
{
    [Table("Pessoa")]
    public class Pessoa
    {
        //public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public Pessoa()
        {

        }
        public Pessoa(string _nome, string _sobrenome, string _cidade)
        {
            Nome = _nome;
            Sobrenome = _sobrenome;
            Cidade = _cidade;   
        }
    }

}