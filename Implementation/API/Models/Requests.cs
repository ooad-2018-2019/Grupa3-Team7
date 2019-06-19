using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Requests
    {
        public Requests()
        {
            ItemCounts = new HashSet<ItemCounts>();
        }

        public string Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string FirmId { get; set; }
        public bool Processed { get; set; }
        public string StorageSpaceId { get; set; }
        public string Discriminator { get; set; }

        public virtual AspNetUsers Firm { get; set; }
        public virtual StorageSpaces StorageSpace { get; set; }
        public virtual ICollection<ItemCounts> ItemCounts { get; set; }
    }
}
