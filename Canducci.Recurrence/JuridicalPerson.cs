﻿namespace Canducci.Recurrence
{
    using Canducci.Recurrence.Strings;
    public class JuridicalPerson
    {
        public JuridicalPerson()
        {

        }
        public JuridicalPerson(string corporateName, string cnpj)
        {
            CorporateName = corporateName;
            CNPJ = cnpj;
        }
        public string CorporateName { get; set; }
        public string CNPJ { get; set; }
        public dynamic ToObject()
        {
            return new
            {
                corporate_name = CorporateName,
                cnpj = CNPJ.ToDigitsOnly()
            };
        }
    }
}