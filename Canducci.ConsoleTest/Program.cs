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
            if (planResponse.Status) // Foi criado o plano com sucesso
            {
                //planResponse.Code;
                //planResponse.Name;
                //planResponse.Interval;
                //planResponse.PlanId;
                //planResponse.Repeats;
                //planResponse.Status;
                //planResponse.CreatedAt;                
            }
        }
    }
}
