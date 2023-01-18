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
        public static async Task Start(IConversor conversor)
        {
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
                    var res = await conversor.Converter(req);

                    Console.WriteLine();
                    Console.WriteLine(res);

                    form.ReadData();
                }
                else
                {
                    form.ReadData(validator);
                }
            }
        }
    }
}
