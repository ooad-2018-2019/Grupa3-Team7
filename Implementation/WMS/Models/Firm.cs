using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WMS.Areas.Identity.Data;

namespace WMS.Models
{
    public class Firm : WMSUser
    {
        [Display(Name = "Firm")]
        public string FirmName { get; set; }
        public ICollection<StorageSpace> StorageSpaces { get; set; }
    }
}
