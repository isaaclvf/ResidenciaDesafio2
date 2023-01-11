using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class ConversaoReq
    {
        public ConversaoReq(string moedaOrigem, string moedaDestino, double valorMonetario)
        {
            MoedaOrigem = moedaOrigem;
            MoedaDestino = moedaDestino;
            ValorMonetario = valorMonetario;
        }

        public string MoedaOrigem { get; private set; }
        public string MoedaDestino { get; private set; }
        public double ValorMonetario { get; private set; }
    }
}
