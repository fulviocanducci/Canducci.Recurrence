using System;


namespace Canducci.Recurrence
{
    public class ConditionalDiscount: Discount
    {
        public DateTime UntilDate { get; set; } //YYYY-MM-DD
        public override dynamic ToObject()
        {
            return new
            {
                discount = new
                {
                    type = Type == DiscountType.Currency ? "currency" : "percentage",
                    value = Value,
                    until_date = UntilDate.ToString("yyyy-MM-dd")
                }
            };
        }
    }
}
