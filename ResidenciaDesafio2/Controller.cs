using ResidenciaDesafio2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class Controller
    {
        public static async void Start(List<string> moedasValidas)
        {
            using HttpClient client = new();

            bool isValid = false;
            var form = new ConversaoForm();
            var validator = new ConversaoValidator(moedasValidas);
            var conversor = new Conversor(client);

            form.ReadData();

            while (!isValid)
            {
                isValid = validator.IsValid(form.MoedaOrigem, form.MoedaDestino, form.ValorMonetario);

                if (isValid && validator.Sair)
                    return;

                if (isValid)
                {
                    var req = new ConversaoReq(validator.Req.MoedaOrigem, validator.Req.MoedaDestino, validator.Req.ValorMonetario);
                    var res = await conversor.Converter(req); // TODO: Em Program.cs funciona, mas aqui não
                    Console.WriteLine(res);
                }
                else
                {
                    form.ReadData(validator);
                }
            }
        }
    }
}
