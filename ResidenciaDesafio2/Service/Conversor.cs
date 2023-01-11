using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResidenciaDesafio2.Service
{
    public class Conversor
    {
        public HttpClient _client { get; private set; }

        public Conversor(HttpClient client)
        {
            _client = client;
        }
        public async Task<Conversao?> Converter(string moedaOrigem, string moedaDestino, double valorMonetario)
        {
            var requestURL = String.Format("https://api.exchangerate.host/convert?from={0}&to={1}&amount={2}",
                moedaOrigem,
                moedaDestino,
                valorMonetario.ToString().Replace(',', '.'));

            var json = await _client.GetStringAsync(requestURL);
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var conversaoObj = JsonSerializer.Deserialize<Conversao>(json, serializeOptions);
            return conversaoObj;
        }
    }
}
