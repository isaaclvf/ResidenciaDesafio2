using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenciaDesafio2
{
    public class ValidationErrors
    {
        private readonly Dictionary<Field, string> errors;

        public ValidationErrors()
        {
            errors = new();
        }

        public void AddError(Field field, string message)
        {
            errors.Add(field, message);
        }

        public void Clear()
        {
            errors.Clear();
        }
        public bool IsEmpty => errors.Count == 0;

        public bool HasError(Field field)
        {
            return errors.TryGetValue(field, out var _);
        }

        public string GetErrorMessage(Field field)
        {
            return HasError(field) ? errors[field] : string.Empty;
        }
    }
}
