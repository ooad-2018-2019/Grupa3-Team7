using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class StorageSpace
    {
        public string Id  { get; set; }
        public double Capacity { get; set; }
        public double UsedUp { get { return 0; } }
        public ICollection<Item> Items { get; set; }
        public Firm Firm { get; set; }

    }
}
