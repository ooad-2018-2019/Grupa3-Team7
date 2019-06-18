using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class StorageSpace
    {
        public string Id  { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double UsedUp {
            get {
                double usedUp = 0;
                foreach(Item item in Items) {
                    usedUp += item.ItemDetails.Volume;
                }
                usedUp /= Capacity;
                return usedUp;
            }
        }

        public ICollection<Item> Items { get; set; }
        public Firm Firm{ get; set; }
    }
}
