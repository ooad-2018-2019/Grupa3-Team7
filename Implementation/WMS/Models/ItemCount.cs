using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class ItemCount
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public Request Request { get; set; }
        public ItemDetails Item { get; set; }
        public int Count { get; set; }
    }
}
