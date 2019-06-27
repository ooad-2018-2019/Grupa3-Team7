using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class ExportRequest : Request
    {
        public override bool isValid()
        {
            foreach(ItemCount itemCount in Items)
            {
                var numOfTheseItemsInStorage = StorageSpace.Items.Count(i => i.ItemDetails == itemCount.Item);
                if (itemCount.Count > numOfTheseItemsInStorage)
                    return false;
            }

            return true;
        }
    }
}
