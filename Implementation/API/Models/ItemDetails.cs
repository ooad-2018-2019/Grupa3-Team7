using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ItemDetails
    {
        public ItemDetails()
        {
            ItemCounts = new HashSet<ItemCounts>();
            Items = new HashSet<Items>();
        }

        public string Upc { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }

        public virtual ICollection<ItemCounts> ItemCounts { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
