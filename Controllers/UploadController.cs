using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using PCI_Website_2018.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net.Http.Headers;

namespace PCI_Website_2018.Controllers

{
    public class UploadController : Controller
    {
        // private readonly IHostingEnvironment _hostingEnvironment;
        // public UploadController(IHostingEnvironment hostingEnvironment)
        // {
        //     _hostingEnvironment = hostingEnvironment;
        // }
        private readonly PCI_Website_2018.Models.UploadContext _context;
        public UploadController(PCI_Website_2018.Models.UploadContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Upload Upload { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Input()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        // POST: Upload/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarouselImg")] Upload upload, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upload);
                var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var fileByte = ms.ToArray();
                upload.CarouselImg = fileByte;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return NotFound();
            }
        }
        
    }
}
