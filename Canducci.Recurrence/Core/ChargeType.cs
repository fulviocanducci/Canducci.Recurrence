using Canducci.Recurrence.Models;

namespace Canducci.Recurrence.Core
{
    public abstract class ChargeType // classe base de cobrança para boleto e cartão
    {
        public Customer Customer { get; set; }
        public string Message { get; set; }
        public Discount Discount { get; set; }
        public abstract dynamic ToObject();
    }
}