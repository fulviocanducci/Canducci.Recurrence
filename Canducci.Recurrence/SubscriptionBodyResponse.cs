using System;
using System.Collections.Generic;
using System.Linq;

namespace Canducci.Recurrence
{
    public class SubscriptionBodyResponse
    {        
        public SubscriptionBodyResponse(int code,
            int subscriptionId,
            string subscriptionStatus,
            string customId,
            List<Charge> charges,
            DateTime createdAt
            )
        {
            Code = code;
            SubscriptionId = subscriptionId;
            SubscriptionStatus = subscriptionStatus;
            Charges = charges;
            CustomId = customId;
            CreatedAt = createdAt;
        }
        public int Code { get; }
        public bool Status { get { return Code == 200; } }
        public int SubscriptionId { get; }
        public string SubscriptionStatus { get; }
        public string CustomId { get; }
        public List<Charge> Charges { get; }
        public DateTime CreatedAt { get; }        
    }
}
