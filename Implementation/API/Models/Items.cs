using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Items
    {
        public string Id { get; set; }
        public string ItemDetailsUpc { get; set; }
        public string StorageSpaceId { get; set; }

        public virtual ItemDetails ItemDetailsUpcNavigation { get; set; }
        public virtual StorageSpaces StorageSpace { get; set; }
    }
}
