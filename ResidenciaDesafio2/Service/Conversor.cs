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

        public static async Task<List<string>> GetMoedasValidas(HttpClient client)
        {
            List<string> moedasValidas = new();

            var json = await client.GetStringAsync("https://api.exchangerate.host/latest");
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
