using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class ItemDetails
    {
        [Key]
        public string UPC { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }

    }
}
