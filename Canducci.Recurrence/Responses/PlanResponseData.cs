using System;
using System.Collections.Generic;

namespace Canducci.Recurrence.Responses
{
    public class PlanResponseData
    {
        public PlanResponseData(int planId, string name, int interval, int? repeats, DateTime createdAt)
        {
            PlanId = planId;
            Name = name;
            Interval = interval;
            Repeats = repeats;
            CreatedAt = createdAt;
        }
        public int PlanId { get; }
        public string Name { get; }
        public int Interval { get; }
        public int? Repeats { get; }
        public DateTime CreatedAt { get; }
    }

    public class PlanResponseDatas : List<PlanResponseData> { }
}
