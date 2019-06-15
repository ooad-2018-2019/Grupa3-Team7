using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Warehouse
    {
        public double Capacity { get; set; }
        public ICollection<StorageSpace> StorageSpaces { get; set; }

    }
}
