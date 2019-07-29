using Canducci.Recurrence.Extensions;
using System.Dynamic;

namespace Canducci.Recurrence.Models
{
    public class Customer : People
    {
        public Address Address { get; set; }
        public JuridicalPerson JuridicalPerson { get; set; }
        public override dynamic ToObject()
        {
            dynamic customer = new ExpandoObject();
            customer.name = Name;
            customer.cpf = CPF.ToDigitsOnly();
            customer.phone_number = PhoneNumber.ToDigitsOnly();
            customer.birth = Birth.ToStringDate();
            customer.address = Address.ToObject();
            customer.email = Email;
            if (JuridicalPerson != null)
            {
                customer.juridical_person = JuridicalPerson.ToObject();
            }
            return customer;
        }
    }
}
