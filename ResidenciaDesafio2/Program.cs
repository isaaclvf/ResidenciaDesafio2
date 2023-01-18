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

// TODO: Não funciona quando extraído em um método
// Controller.Start() 
var moedas = await conversor.GetMoedasValidas();
bool isValid = false;
var form = new ConversaoForm();
var validator = new ConversaoValidator(moedas);

form.ReadData();

while (!isValid)
{
    if (form.Sair) break;

    isValid = validator.IsValid(form.MoedaOrigem, form.MoedaDestino, form.ValorMonetario);

    if (isValid)
    {
        var req = new ConversaoReq(validator.Req.MoedaOrigem, validator.Req.MoedaDestino, validator.Req.ValorMonetario);
        var res = await conversor.Converter(req); // Aqui funciona
        Console.WriteLine(res);
    }
    else
    {
        form.ReadData(validator);
    }
}