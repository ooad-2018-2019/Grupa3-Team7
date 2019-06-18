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
        [Key, Column(Order = 0)]
        public ItemDetails Item { get; set; }
        [Key, Column(Order = 1)]
        public int Count { get; set; }
    }
}
