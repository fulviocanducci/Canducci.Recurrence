namespace Canducci.Recurrence
{
    public class CreditCard : ChargeType // Cartão de crédito
    {
        public BillingAddress BillingAddress { get; set; }
        public string PaymentToken { get; set; }
        public int? TrialDays { get; set; }
        public override dynamic ToObject()
        {
            dynamic credit_card = new
            {
                credit_card = base.ToObject()                
            };
            credit_card.billing_address = BillingAddress.ToObject();
            credit_card.payment_token = PaymentToken;
            credit_card.trial_days = TrialDays;
            return credit_card;
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