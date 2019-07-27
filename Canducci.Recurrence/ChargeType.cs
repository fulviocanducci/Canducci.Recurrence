namespace Canducci.Recurrence
{
    public abstract class ChargeType // classe base de cobrança para boleto e cartão
    {
        public Customer Customer { get; set; }
        public string Message { get; set; }
        public Discount Discount { get; set; }
        public virtual dynamic ToObject()
        {
            return new
            {
                customer = Customer.ToObject(),
                message = Message,
                discount = Discount.ToObject()
            };
        }
    }
}