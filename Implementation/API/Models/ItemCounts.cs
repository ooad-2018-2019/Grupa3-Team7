using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ItemCounts
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public string ItemUpc { get; set; }
        public int Count { get; set; }

        public virtual ItemDetails ItemUpcNavigation { get; set; }
        public virtual Requests Request { get; set; }
    }
}
