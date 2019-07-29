using System.Dynamic;
namespace Canducci.Recurrence.Models
{
    public class CreditCard : Core.ChargeType // Cartão de crédito
    {
        public BillingAddress BillingAddress { get; set; }
        public string PaymentToken { get; set; }
        public int? TrialDays { get; set; }
        public override dynamic ToObject()
        {
            dynamic payment = new ExpandoObject();
            payment.payment = new ExpandoObject();
            payment.payment.credit_card = new ExpandoObject();
            payment.payment.credit_card.customer = Customer.ToObject();
            payment.payment.credit_card.billing_address = BillingAddress.ToObject();
            payment.payment.credit_card.payment_token = PaymentToken;
            if (Discount != null)
            {
                payment.payment.credit_card.discount = Discount.ToObject();
            }
            if (!string.IsNullOrEmpty(Message))
            {
                payment.payment.credit_card.message = Message;
            }
            if (TrialDays.HasValue)
            {
                payment.payment.credit_card.trial_days = TrialDays;
            }
            return (object)payment;           
        }
    }
}
//"credit_card"
//    "customer"
//        "name"
//        "cpf"
//        "email"
//        "phone_number"
//        "birth"
//        "address"
//            "street"
//            "number"
//            "neighborhood"
//            "zipcode"
//            "city"
//            "complement"
//            "state"
//        "juridical_person"
//            "corporate_name"
//            "cnpj"
//    "billing_address"
//        "street"
//        "number"
//        "neighborhood"
//        "zipcode"
//        "city"
//        "complement"
//        "state"
//    "payment_token"
//    "discount"
//        "type"
//            "percentage"
//            "currency"
//        "value"
//    "message"
//    "trial_days"