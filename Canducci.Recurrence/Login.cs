using Gerencianet.SDK;
namespace Canducci.Recurrence
{
    public class Login
    {
        public dynamic Endpoints { get; }
        public Login(Endpoints endpoints)
        {
            Endpoints = endpoints;            
        }
        public Login(string clientId, string clientSecret, bool sandbox = true)
        {
            Endpoints = new Endpoints(clientId, clientSecret, sandbox);
        }
    }
}
