using Canducci.Recurrence.Extensions;
using System;
using System.Dynamic;

namespace Canducci.Recurrence.Models
{
    public class BankingBillet : Core.ChargeType //boleto bancário
    {        
        public DateTime ExpireAt { get; set; }
        public ConditionalDiscount ConditionalDiscount { get; set; }
        public Configurations Configurations { get; set; }
        public override dynamic ToObject()
        {
            dynamic payment = new ExpandoObject();
            payment.payment = new ExpandoObject();
            payment.payment.banking_billet = new ExpandoObject();
            payment.payment.banking_billet.customer = Customer.ToObject();
            payment.payment.banking_billet.expire_at = ExpireAt.ToStringDate();
            if (Discount != null)
            {
                payment.payment.banking_billet.discount = Discount.ToObject();
            }
            if (ConditionalDiscount != null)
            {
                payment.payment.banking_billet.conditional_discount = ConditionalDiscount.ToObject();
            }
            if (Configurations != null)
            {
                payment.payment.banking_billet.configurations = Configurations.ToObject();
            }
            payment.payment.banking_billet.message = Message;
            return (object)payment;      
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
