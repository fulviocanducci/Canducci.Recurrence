namespace Canducci.Recurrence
{
    using System;

    public class PlanResponse
    {
        public PlanResponse(int code, int planId, string name, int interval, int? repeats, DateTime createdAt)
        {
            Code = code;
            PlanId = planId;
            Name = name;
            Interval = interval;
            Repeats = repeats;
            CreatedAt = createdAt;
        }
        public PlanResponse(int code)
        {
            Code = code;
        }
        public int Code { get; set; }
        public bool Status {
            get
            {
                return Code == 200;
            }
        }
        public int PlanId { get; }
        public string Name { get; }
        public int Interval { get; }
        public int? Repeats { get; }
        public DateTime CreatedAt { get; }
    }
}
