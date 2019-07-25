namespace Canducci.Recurrence
{
    public class Metadatas
    {
        public Metadatas(string notificationUrl, string customId)
        {
            NotificationUrl = notificationUrl;
            CustomId = customId;
        }
        public string NotificationUrl { get; }
        public string CustomId { get; }
        public dynamic ToObject()
        {
            return new
            {
                custom_id = CustomId,
                notification_url = NotificationUrl
            };
        }
    }
}
