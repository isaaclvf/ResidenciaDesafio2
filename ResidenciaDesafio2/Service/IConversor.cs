using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2.Service
{
    public interface IConversor
    {
        Task<Conversao?> Converter(ConversaoReq req);
        Task<Conversao?> Converter(string moedaOrigem, string moedaDestino, double valorMonetario);
        Task<List<string>> GetMoedasValidas();
    }
}
