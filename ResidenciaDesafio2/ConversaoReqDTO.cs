using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class ConversaoReqDTO
    {
        public string MoedaOrigem { get; set; } = string.Empty;
        public string MoedaDestino { get; set; } = string.Empty;
        public double ValorMonetario { get; set; } = 0;
    }
}
