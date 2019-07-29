using System.Collections.Generic;
using System.Linq;
namespace Canducci.Recurrence.Models
{
    public class SubscriptionBody
    {
        public List<SubscriptionItem> SubscriptionItems { get; }
        public List<Shippings> Shippings { get; set; }
        public List<Metadatas> Metadatas { get; set; }
        public SubscriptionBody(List<SubscriptionItem> items)
        {
            SubscriptionItems = items;
            Shippings = new List<Shippings>();
            Metadatas = new List<Metadatas>();
        }
        public SubscriptionBody(params SubscriptionItem[] items)
        {
            SubscriptionItems = items.ToList();
            Shippings = new List<Shippings>();
            Metadatas = new List<Metadatas>();
        }
        public SubscriptionBody(List<SubscriptionItem> items, List<Shippings> shippings)
        {
            SubscriptionItems = items;
            Shippings = shippings;
            Metadatas = new List<Metadatas>();
        }
        public SubscriptionBody(List<SubscriptionItem> items, List<Shippings> shippings, List<Metadatas> metadatas)
        {
            SubscriptionItems = items;
            Shippings = shippings;
            Metadatas = metadatas;
        }
        public dynamic ToObjects()
        {
            if (Shippings.Count > 0 && Metadatas.Count > 0)
            {
                return new
                {
                    items = SubscriptionItems.Select(x => x.ToObject()),
                    shippings = Shippings.Select(x => x.ToObject()),
                    metadata = Metadatas.Select(x => x.ToObject())
                };
            }
            if (Shippings.Count > 0)
            {
                return new
                {
                    items = SubscriptionItems.Select(x => x.ToObject()),
                    shippings = Shippings.Select(x => x.ToObject())
                };
            }
            if (Metadatas.Count > 0)
            {
                return new
                {
                    items = SubscriptionItems.Select(x => x.ToObject()),                    
                    metadata = Metadatas.Select(x => x.ToObject())
                };
            }
            return new
            {
                items = SubscriptionItems.Select(x => x.ToObject())
            };
        }
    }
}
