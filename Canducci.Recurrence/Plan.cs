namespace Canducci.Recurrence
{
    using System;
    using System.Collections.Generic;    
    public class Plan
    {
        private Login Login { get; }        
        public Plan(Login login)
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

        public SubscriptionBodyResponse CreateSubscription(int planId, SubscriptionBody items)
        {
            var param = new
            {
                id = planId
            };            
            var result = Login.EndPoints.CreateSubscription(param, items.ToObjects());            
            List<Charge> charges = new List<Charge>();
            var chargesJToken = ((Newtonsoft.Json.Linq.JArray)result.data.charges)
                .GetEnumerator();
            while (chargesJToken.MoveNext())
            {
                dynamic x = chargesJToken.Current;
                if (x != null)
                {
                    charges.Add(new Charge(
                        (int)x.charge_id, 
                        (string)x.status, 
                        (int)x.total, 
                        (int)x.parcel)
                        );
                }
            }
            return new SubscriptionBodyResponse(
                (int)result.code,
                (int)result.data.subscription_id,
                (string)result.data.status,
                (string)result.data.customId,
                charges,
                DateTime.Parse((string)result.data.created_at)
                );
        }
    }
}
