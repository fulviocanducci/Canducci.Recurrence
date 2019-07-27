using System;

namespace Canducci.Recurrence
{
    public class BankingBillet : ChargeType //boleto bancário
    {        
        public DateTime ExpireAt { get; set; }
        public ConditionalDiscount ConditionalDiscount { get; set; }
        public Configurations Configurations { get; set; }
        public override dynamic ToObject()
        {
            dynamic banking_billet = new
            {
                banking_billet = base.ToObject()
            };
            banking_billet.expire_at = ExpireAt.ToString("yyyy-MM-dd");            
            banking_billet.conditional_discount = ConditionalDiscount.ToObject();
            banking_billet.configurations = Configurations.ToObject();
            return banking_billet;
        }
    }
}
//"banking_billet"
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
//    "expire_at"
//    "discount"
//        "type"
//            "percentage"
//            "currency"
//        "value"
//    "conditional_discount"
//        "type"
//            "percentage",
//            "currency"
//        "value"
//        "until_date"
//    "configurations"
//        "fine"
//        "interest"
//    "message"
