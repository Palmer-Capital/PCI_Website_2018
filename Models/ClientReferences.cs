using System;
using System.Collections.Generic;

namespace PCI_Website_2018.Models
{
    public partial class ClientReferences
    {
        public int RefPrimaryId { get; set; }
        public int? RefOrder { get; set; }
        public string RefFullname { get; set; }
        public string RefCompany { get; set; }
        public string RefAddress { get; set; }
        public string RefCityStzip { get; set; }
        public string RefPhone { get; set; }
        public string RefFax { get; set; }
    }
}
