using Canducci.Recurrence;
namespace Canducci.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string clientId = "";
            const string clientSecret = "";
            Login login = new Login(clientId, clientSecret);
            Plan plan = new Plan(login);
            Body body = new Body("Plano Teste 001", 1, null);
            PlanResponse planResponse = plan.Create(body);
            if (planResponse.Status) // foi criado ...
            {

            }
        }
    }
}
