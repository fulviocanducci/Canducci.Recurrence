using Canducci.Recurrence.Models;
namespace Canducci.Recurrence
{
    public sealed class CreditCards
    {
        private Login Login { get; }
        public CreditCards(Login login)
        {
            Login = login;
        }
        public dynamic Create(int id, CreditCard body)
        {
            var param = new
            {
                id //<%-- informe o subscription_id --%>
            };
            return Login.EndPoints.PaySubscription(param, body.ToObject());
        }
        public static CreditCards Create(Login login) => new CreditCards(login);
    }
}
