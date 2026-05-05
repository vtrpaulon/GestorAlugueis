using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAlugueis.DTOs
{
    public class ImovelCreateDto
    {
        public string Endereco { get; set; } = string.Empty;
        public decimal ValorAluguel { get; set; }
        public bool Disponivel { get; set; }
    }
}