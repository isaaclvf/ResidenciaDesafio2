using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class ConversaoForm
    {
        public string? MoedaOrigem { get; private set; }
        public string? MoedaDestino { get; private set; }
        public string? ValorMonetario { get; private set; }

        public void ReadData()
        {
            ReadData(null);
        }

        public void ReadData(ConversaoValidator? validator)
        {
            if (validator != null)
            {
                Console.WriteLine();
                foreach (Field field in Enum.GetValues(typeof(Field)))
                {
                    var msg = validator.Errors.GetErrorMessage(field);

                    if (msg.Length > 0)
                        Console.WriteLine("{0}: {1}", field.ToString(), msg);
                }
                Console.WriteLine();
            }

            if (validator == null || validator.Errors.HasError(Field.MOEDA_ORIGEM))
            {
                Console.Write("Moeda origem: "); // UNDONE: Retornar aqui
                MoedaOrigem = Console.ReadLine()?.ToUpper();
            }

            if (validator == null || validator.Errors.HasError(Field.MOEDA_DESTINO))
            {
                Console.Write("Moeda destino: ");
                MoedaDestino = Console.ReadLine()?.ToUpper();
            }

            if (validator == null || validator.Errors.HasError(Field.VALOR_MONETARIO))
            {
                Console.Write("Valor: ");
                ValorMonetario = Console.ReadLine();
            }
        }
    }
}
