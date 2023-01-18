using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResidenciaDesafio2.Service
{
    public class ConversorComExchangerate : IConversor
    {
        public HttpClient _client { get; private set; }

        public ConversorComExchangerate(HttpClient client)
        {
            _client = client;
        }

        public async Task<Conversao?> Converter(ConversaoReq req)
        {
            return await Converter(req.MoedaOrigem, req.MoedaDestino, req.ValorMonetario);
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

        public async Task<List<string>> GetMoedasValidas()
        {
            // TODO: Usar endpoint específico para pegar as moedas: https://api.exchangerate.host/symbols
            List<string> moedasValidas = new();

            var json = await _client.GetStreamAsync("https://api.exchangerate.host/latest");
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var latestChanges = JsonSerializer.Deserialize<LatestChanges>(json, serializeOptions);

            foreach (var item in latestChanges.Rates)
                moedasValidas.Add(item.Key);

            return moedasValidas;
        }
    }
}
