using System;
using Canducci.Recurrence.Extensions;
namespace Canducci.Recurrence.Models
{
    public class SubscriptionItem
    {
        public SubscriptionItem(string name, int amount, decimal value)
        {
            Name = name;
            Amount = amount;
            Value = value;
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.FormatException("Mínimo de 1 caractere e máximo de 255 caracteres.");
                }
                if (value.Length <= 0 || value.Length > 255)
                {
                    throw new System.FormatException("Mínimo de 1 caractere e máximo de 255 caracteres.");
                }
                name = value;

            }
        }
        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value <=0)
                {
                    throw new FormatException("Mínimo de 1 (Integer)");
                }
                amount = value;
            }
        }
        private decimal value;
        public decimal Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Mínimo de 1 real");
                }
                this.value = value;
            }
        }
        public dynamic ToObject()
        {
            return new
            {
                name = Name,
                value = value.ToMultiple(),
                amount = Amount
            };
        }
    }
}
