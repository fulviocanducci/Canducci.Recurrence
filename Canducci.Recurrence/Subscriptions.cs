using System;
using System.Collections.Generic;
using Canducci.Recurrence.Models;
using Canducci.Recurrence.Responses;
namespace Canducci.Recurrence
{
    public sealed class Subscriptions
    {
        private Login Login { get; }
        public Subscriptions(Login login)
        {
            Login = login;
        }
        public SubscriptionBodyResponse Create(PlanResponse planResponse, SubscriptionBody items)
            => Create(planResponse.PlanId, items);
        public SubscriptionBodyResponse Create(int planId, SubscriptionBody items)
        {
            var param = new
            {
                id = planId
            };
            var result = Login.EndPoints.CreateSubscription(param, items.ToObjects());
            List<Charge> charges = new List<Charge>();
            var chargesJToken = ((Newtonsoft.Json.Linq.JArray)result.data.charges).GetEnumerator();
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
        public static Subscriptions Create(Login login) => new Subscriptions(login);
    }
}
