using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class ConversaoValidator
    {
        private readonly ValidationErrors errors = new();
        private readonly List<string> moedasValidas;

        public ConversaoValidator(List<string> moedasValidas)
        {
            Req = new();
            this.moedasValidas = moedasValidas;
        }

        public ConversaoReqDTO Req { get; private set; }
        public ValidationErrors Errors { get { return errors; } }
        public bool Sair { get; private set; }

        public bool IsValid(string? moedaOrigem, string? moedaDestino, string? strValor)
        {
            errors.Clear();

            // TODO: Arrumar isso
            Sair = false;
            if (moedaOrigem == null)
            {
                Sair = true;
                return Sair;
            }

            // Moeda origem
            if (moedaOrigem.Length != 3)
                errors.AddError(Field.MOEDA_ORIGEM, "Moeda origem deve ter exatamente 3 caracteres");
            if (!moedasValidas.Contains(moedaOrigem))
                errors.AddError(Field.MOEDA_ORIGEM, "Moeda inválida");
            else
                Req.MoedaOrigem = moedaOrigem;

            // Moeda destino
            if (moedaDestino.Length != 3)
                errors.AddError(Field.MOEDA_DESTINO, "Moeda destino deve ter exatamente 3 caracteres");
            if (moedaDestino == moedaOrigem)
                errors.AddError(Field.MOEDA_DESTINO, "As moedas devem ser diferentes");
            if (!moedasValidas.Contains(moedaDestino))
                errors.AddError(Field.MOEDA_DESTINO, "Moeda inválida");
            else
                Req.MoedaDestino = moedaDestino;

            // Valor
            strValor ??= "1"; // Valor padrão caso o usuário não digite nada
            try
            {
                Req.ValorMonetario = Convert.ToDouble(strValor);

                if (Req.ValorMonetario <= 0)
                    errors.AddError(Field.VALOR_MONETARIO, "Valor deve ser maior que 0");
            }
            catch (Exception)
            {
                errors.AddError(Field.VALOR_MONETARIO, "Valor inválido");
            }

            return errors.IsEmpty;
        }
    }
}
