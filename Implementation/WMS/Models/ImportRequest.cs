using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class ImportRequest : Request
    {
        public override bool isValid()
        {
            var capacity = Items.Sum(ic => ic.Item.Volume);
            return capacity > StorageSpace.Capacity * (1 - StorageSpace.UsedUp);
        }
    }
}
