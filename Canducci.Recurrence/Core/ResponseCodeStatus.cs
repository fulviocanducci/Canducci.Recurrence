namespace Canducci.Recurrence.Core
{
    public abstract class ResponseCodeStatus
    {
        public int Code { get; set; }
        public bool Status
        {
            get
            {
                return Code == 200;
            }
        }
    }
}