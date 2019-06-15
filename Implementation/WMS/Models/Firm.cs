using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Firm : IdentityUser
    {
        public string FirmName { get; set; }
    }
}
