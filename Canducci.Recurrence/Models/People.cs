using Canducci.Recurrence.Extensions;
using System;

namespace Canducci.Recurrence.Models
{
    public abstract class People
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth { get; set; }  
        public string Email { get; set; }
        public virtual dynamic ToObject()
        {
            return new
            {
                name = Name,
                cpf = CPF,
                email = Email,
                phone_number = PhoneNumber,
                birth = Birth.ToStringDate()
            };
        }
    }
}