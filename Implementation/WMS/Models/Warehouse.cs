using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Warehouse
    {
        [Key]
        public string WarehouseId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Capacity { get; set; }
        public double UsedUp { get; set; }
    }
}
