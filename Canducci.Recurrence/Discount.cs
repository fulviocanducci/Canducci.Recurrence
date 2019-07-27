namespace Canducci.Recurrence
{
    public class Discount
    {
        public DiscountType Type { get; set; }
        public int Value { get; set; }
        public virtual dynamic ToObject()
        {
            return new
            {
                type = Type == DiscountType.Currency ? "currency" : "percentage",
                value = Value
            };
        }
    }
}