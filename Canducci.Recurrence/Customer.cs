namespace Canducci.Recurrence
{
    public class Customer : People
    {
        public Address Address { get; set; }
        public JuridicalPerson JuridicalPerson { get; set; }
        public override dynamic ToObject()
        {
            dynamic value = base.ToObject();
            value.customer.address = Address.ToObject();
            if (JuridicalPerson != null)
            {
                value.juridical_person = JuridicalPerson.ToObject();
            }
            return value;
        }
    }
}
