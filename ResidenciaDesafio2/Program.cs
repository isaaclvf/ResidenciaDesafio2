using ResidenciaDesafio2;
using ResidenciaDesafio2.Service;

using HttpClient client = new();
var moedas = await Conversor.GetMoedasValidas(client);

// Testes

//foreach (var m in moedas)
//{
//    Console.WriteLine(m);
//}

//var conversor = new Conversor(client);
//var resultado = await conversor.Converter("BRL", "USD", 100);
//Console.WriteLine(resultado);

Controller.Start(moedas);