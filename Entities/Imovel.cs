using GestorAlugueis;

namespace GestorAlugueis.Entities
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public decimal ValorAluguel { get; set; }
        public bool Disponivel { get; set; }

        public Imovel()
        {

        }
        public Imovel(string endereco, decimal valorAluguel, bool disponivel)
        {            
            Endereco = endereco;
            ValorAluguel = valorAluguel;
            Disponivel = disponivel;
        }
    }
}