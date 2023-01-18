using ResidenciaDesafio2;
using ResidenciaDesafio2.Service;

using HttpClient client = new();
var conversor = new ConversorComExchangerate(client);

// Testes

// var moedas = await conversor.GetMoedasValidas();
// foreach (var m in moedas)
// {
//     Console.WriteLine(m);
// }

// var resultado = await conversor.Converter("BRL", "USD", 100);
// Console.WriteLine(resultado);

await Controller.Start(conversor);