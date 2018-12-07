using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PCI_Website_2018.Models
{
    public class WebsiteTransactions
    {
        public int WtrPrimaryId { get; set; }
        public string WtrName { get; set; }
        public string WtrCity { get; set; }
        public string WtrState { get; set; }
        public string WtrSize { get; set; }
        public string WtrType { get; set; }
        public string WtrImage { get; set; }
        public string WtrDescription { get; set; }
        public int? WtrSizeNumeric { get; set; }
    }
}
