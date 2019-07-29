using Gerencianet.SDK;
namespace Canducci.Recurrence
{
    public class Login
    {
        public dynamic EndPoints { get; }        
        public Login(Endpoints endpoints)
        {
            EndPoints = endpoints;            
        }
        public Login(string clientId, string clientSecret, bool sandbox = true)
        {
            EndPoints = new Endpoints(clientId, clientSecret, sandbox);            
        }
        public static Login Create(Endpoints endpoints) 
            => new Login(endpoints);
        public static Login Create(string clientId, string clientSecret, bool sandbox = true) 
            => new Login(clientId, clientSecret, sandbox);
    }
}
