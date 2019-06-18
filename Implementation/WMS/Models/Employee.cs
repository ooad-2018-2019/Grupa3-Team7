using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.Areas.Identity.Data;

namespace WMS.Models
{
    public class Employee : WMSUser
    {
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
    }
}
