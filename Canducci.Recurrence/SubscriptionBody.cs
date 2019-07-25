using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canducci.Recurrence
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
                value = (Value * 100),
                amount = Amount
            };
        }
    }
    public class SubscriptionBody: 
        List<SubscriptionItem>, 
        IList<SubscriptionItem>
    {
        public dynamic ToObjects()
        {

            //var subscriptionBody = new
            //{
            //    items = new[] {
            //        new {
            //            name = "Product 1",
            //            value = 1000,
            //            amount = 2
            //        }
            //    }
            //};
            var items = new
            {
                items = this.ToList().Select(x => x.ToObject())
            };
            return items;
        }
    }
    public class Charge
    {
        public Charge(int chargeId, string status, int total, int parcel)
        {
            ChargeId = chargeId;
            Status = status;
            Total = total;
            Parcel = parcel;
        }
        public int ChargeId { get; }
        public string Status { get; }
        public int Total { get; set; }
        public decimal TotalToDecimal { get { return Total / 100; } }
        public int Parcel { get; }
    }
    public class SubscriptionBodyResponse
    {        
        public SubscriptionBodyResponse(int code,
            int subscriptionId,
            string subscriptionStatus,
            int customId,
            List<Charge> charges,
            DateTime createdAt
            )
        {
            Code = code;
            SubscriptionId = subscriptionId;
            SubscriptionStatus = subscriptionStatus;
            Charges = charges;
            CustomId = CustomId;
            CreatedAt = createdAt;
        }
        public int Code { get; }
        public bool Status { get { return Code == 200; } }
        public int SubscriptionId { get; }
        public string SubscriptionStatus { get; }
        public string CustomId { get; }
        public List<Charge> Charges { get; }
        public DateTime CreatedAt { get; }        
    }
}
