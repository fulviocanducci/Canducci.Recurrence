using Canducci.Recurrence.Extensions;
namespace Canducci.Recurrence.Models
{
    public class Shippings
    {
        public Shippings(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
        public Shippings(string name, decimal value, string payeeCode)
            :this(name, value)
        {
            PayeeCode = payeeCode;
        }
        private string name;
        private decimal _value;        
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new System.FormatException("Máximo de 255 caracteres");
                }
                if (name.Length < 0 && name.Length > 255)
                {
                    throw new System.FormatException("Maior que 0 e menor igual de 255 caracteres");
                }
                name = value;
            }
        }
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value <= 0)
                {
                    throw new System.FormatException("Valor do frete, valor maior que 0");
                }
                _value = value;
            }
        }
        public string PayeeCode { get; set; }
        public dynamic ToObject()
        {
            return new
            {
                name = Name,
                value = Value.ToMultiple(),
                payeeCode = PayeeCode
            };
        }
    }
}
