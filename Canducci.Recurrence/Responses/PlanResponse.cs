namespace Canducci.Recurrence.Responses
{
    public class PlanResponse<T>: Core.ResponseCodeStatus
    {
        public PlanResponse(int code)
        {
            Code = code;
        }
        public PlanResponse(int code, T data)
        {
            Code = code;            
            Data = data;
        }
        public T Data { get; set; } = default;
    }
}
