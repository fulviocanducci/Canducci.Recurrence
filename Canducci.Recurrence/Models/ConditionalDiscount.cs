using Canducci.Recurrence.EnumsType;
using Canducci.Recurrence.Extensions;
using System;
namespace Canducci.Recurrence.Models
{
    public class ConditionalDiscount: Discount
    {
        public DateTime UntilDate { get; set; } //YYYY-MM-DD
        public override dynamic ToObject()
        {
            return new
            {
                type = Type == DiscountType.Currency ? "currency" : "percentage",
                value = Value,
                until_date = UntilDate.ToStringDate()
            };
        }
    }
}
