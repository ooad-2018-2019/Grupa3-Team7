using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class StorageSpaces
    {
        public StorageSpaces()
        {
            Items = new HashSet<Items>();
            Requests = new HashSet<Requests>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public string FirmId { get; set; }
        public bool Available { get; set; }

        public virtual AspNetUsers Firm { get; set; }
        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
