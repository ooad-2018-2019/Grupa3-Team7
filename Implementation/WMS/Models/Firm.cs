using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Firm
    {
        [Key]
        public string FirmName { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public ICollection<StorageSpace> StorageSpaces { get; set; }
    }
}
