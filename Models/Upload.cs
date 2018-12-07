using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace PCI_Website_2018.Models
{
    public class Upload
    {
        [Required]
        public int ID { get; set; }
        
        public byte[] CarouselImg { get; set; }
    }
}   