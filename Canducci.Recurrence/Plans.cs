using System;
using Canducci.Recurrence.Models;
using Canducci.Recurrence.Responses;
namespace Canducci.Recurrence
{
    public class Plans
    {
        private Login Login { get; }        
        public Plans(Login login)
        {
            Login = login;
        }
        public PlanResponse Create(Body body)
        {            
            var result = Login.EndPoints.CreatePlan(null, body.ToObject());            
            if (result.code == 200)
            {                
                return new PlanResponse(
                        (int)result.code,
                        (int)result.data.plan_id,
                        (string)result.data.name,
                        (int)result.data.interval,
                        (object)result.data.repeats != null? (int?)result.data.repeats:null,
                        DateTime.Parse((string)result.data.created_at)
                    );
            }
            return new PlanResponse(result.code);
        }
        public static Plans Create(Login login) => new Plans(login);
    }
}
