using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public abstract class Request
    {
        public string Id { get; set; }
        public DateTime RequestDate { get; set; }
        public Firm Firm { get; set; }
        public bool Processed { get; set; }
        public ICollection<ItemCount> Items{ get; set; }
    }
}
