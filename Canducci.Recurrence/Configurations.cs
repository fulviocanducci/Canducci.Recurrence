namespace Canducci.Recurrence
{
    public class Configurations
    {
        public int Fine { get; set; }
        public int Interest { get; set; }

        public dynamic ToObject()
        {
            return new
            {
                fine = Fine,
                interest = Interest
            };
           
        }
    }
}