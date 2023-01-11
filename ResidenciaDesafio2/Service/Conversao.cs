using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2.Service
{
    public class Conversao
    {
        public bool Success { get; set; }
        public Query? Query { get; set; }
        public Info? Info { get; set; }
        public DateTime Date { get; set; }
        public double Result { get; set; }

        public override string ToString()
        {
            return 
                $"Origem: {Query?.From}\nDestino: {Query?.To}\nValor: {Query?.Amount}\nTaxa: {Info?.Rate}\nResultado: {Math.Round(Result, 2)}\nData: {Date.ToShortDateString()}\n\n";
        }
    }

    public class Query
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public double Amount { get; set; }
    }

    public class Info
    {
        public double Rate { get; set; }
    }
}
