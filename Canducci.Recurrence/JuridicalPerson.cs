namespace Canducci.Recurrence
{
    public class JuridicalPerson
    {
        public JuridicalPerson(string corporateName, string cnpj)
        {
            CorporateName = corporateName;
            CNPJ = cnpj;
        }
        public string CorporateName { get;}
        public string CNPJ { get; }
        public dynamic ToObject()
        {
            return new
            {
                corporate_name = CorporateName,
                cnpj = CNPJ
            };
        }
    }
}