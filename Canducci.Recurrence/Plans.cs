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
        public PlanResponse<PlanResponseData> Create(Body body)
        {            
            var result = Login.EndPoints.CreatePlan(null, body.ToObject());            
            if ((int)result.code == 200)
            {
                return new PlanResponse<PlanResponseData>((int)result.code,
                    new PlanResponseData(
                        (int)result.data.plan_id,
                        (string)result.data.name,
                        (int)result.data.interval,
                        (object)result.data.repeats != null ? (int?)result.data.repeats : null,
                        DateTime.Parse((string)result.data.created_at)
                    ));
            }
            return new PlanResponse<PlanResponseData>(result.code);
        }                
        public dynamic Delete(int id)
        {
            try
            {
                var param = new { id };
                return Login.EndPoints.DeletePlan(param);
            }
            catch (Exception ex) 
            {
                throw ex;
            }            
        }
        internal PlanResponse<PlanResponseDatas> GetAllInternal(dynamic param)
        {
            var result = Login.EndPoints.GetPlans(param);
            var obj = new PlanResponse<PlanResponseDatas>((int)result.code);
            if ((int)result.code == 200)
            {
                obj.Data = new PlanResponseDatas();
                var chargesJToken = ((Newtonsoft.Json.Linq.JArray)result.data).GetEnumerator();
                while (chargesJToken.MoveNext())
                {
                    dynamic current = chargesJToken.Current;
                    if (current != null)
                    {
                        obj.Data.Add(new PlanResponseData(
                            (int)current.plan_id,
                            (string)current.name,
                            (int)current.interval,
                            (object)current.repeats == null ? null : (int?)current.repeats,
                            DateTime.Parse((string)current.created_at)
                            ));
                    }
                }
            }
            return obj;
        }
        public PlanResponse<PlanResponseDatas> GetAll(string name, int limit = 20, int offset = 0)
        {
            return GetAllInternal(new { name, limit, offset });
        }
        public PlanResponse<PlanResponseDatas> GetAll(int limit = 20, int offset = 0)
        {
            return GetAllInternal(new { limit, offset });
        }
        public static Plans Create(Login login) => new Plans(login);
    }
}
