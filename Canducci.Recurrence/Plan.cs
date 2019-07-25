namespace Canducci.Recurrence
{
    using System;
    using System.Globalization;
    public class Plan
    {
        public Login Login { get; }
        public Plan(Login login)
        {
            Login = login;
        }
        public PlanResponse Create(Body body)
        {            
            var result = Login.Endpoints.CreatePlan(null, body.ToObject());            
            if (result.code == 200)
            {
                return new PlanResponse(
                        result.code,
                        result.data.plan_id,
                        result.data.name,
                        result.data.interval,
                        result.data.repeats,
                        DateTime.ParseExact(result.data.created_at, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    );
            }
            return new PlanResponse(result.code);
        }
    }

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
