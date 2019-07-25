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
            var result = Login.EndPoints.CreatePlan(null, body.ToObject());            
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
}
