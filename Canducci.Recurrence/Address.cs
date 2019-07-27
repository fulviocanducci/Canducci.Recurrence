namespace Canducci.Recurrence
{
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public dynamic ToObject()
        {
            return new
            {
                street = Street,
                number = Number,
                neighborhood = Neighborhood,
                zipcode = Zipcode,
                city = City,
                complement = Complement,
                state = State
            };
        }
    }
}