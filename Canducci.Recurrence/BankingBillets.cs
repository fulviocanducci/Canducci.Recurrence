using Canducci.Recurrence.Models;
namespace Canducci.Recurrence
{
    public sealed class BankingBillets
    {
        private Login Login { get; }
        public BankingBillets(Login login)
        {
            Login = login;
        }
        public dynamic Create(int id, BankingBillet body)
        {
            var param = new
            {
                id //.charge_id # <%-- informe o charge_id --%>
            };
            return Login.EndPoints.PaySubscription(param, body.ToObject());
        }
        public static BankingBillets Create(Login login) => new BankingBillets(login);
    }
}
