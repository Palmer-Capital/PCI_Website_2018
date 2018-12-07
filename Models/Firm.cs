using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;

namespace PCI_Website_2018.Models
{
    public class Firm
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string College { get; set; }
        public string Degree { get; set; }
        public string ImgURL { get; set; }
    }
}