using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCI_Website_2018.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PCI_Website_2018.Controllers
{
    public class FirmController : Controller
    {
        private readonly FirmContext _context;

        public FirmController(FirmContext context)
        {
            _context = context;
        }
        public Firm firm { get; set; }
        // GET: Firm
        public async Task<IActionResult> Index(int id)
        {    
            //for nav active states – so know which page
            ViewData["Active"] = "Firm";
            //******************************************

            //routing from contact page ...
            if (id == 1 )
            {
                //in view...if data is not "" then display contact link in nav tree, otherwise show firm link ...
                ViewData["Contact"] = "x";
            }     

            var firm = await _context.Firm
                .OrderBy(m => m.LastName)
                .ToListAsync();

            if (firm == null)
            {
                TempData["Error"] = "firm"; //for error message tailored to user
                return RedirectToAction("Error");
            }

            return View(firm);
        }
        public async Task<IActionResult> Firm_IP(int id)
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Firm";
            //******************************************

            //routing from contact page ...
            if (id == 1 )
            {
                //in view...if data is not "" then display contact link in nav tree, otherwise show firm link ...
                ViewData["Contact"] = "x";
            }     

            var firm = await _context.Firm
            .Where(m => m.Title.Contains("Investment Partner"))
                .OrderBy(m => m.LastName)
                .ToListAsync();

            if (firm == null)
            {
                TempData["Error"] = "firm"; //for error message tailored to user
                return RedirectToAction("Error");
            }

            return View(firm);
        }
        public async Task<IActionResult> Firm_President(int id)
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Firm";
            //******************************************

            //routing from contact page ...
            if (id == 1 )
            {
                //in view...if data is not "" then display contact link in nav tree, otherwise show firm link ...
                ViewData["Contact"] = "x";
            }       

            var firm = await _context.Firm
            .Where(m => m.Title.Contains("President & CEO"))
                .OrderBy(m => m.LastName)
                .ToListAsync();

            if (firm == null)
            {
                TempData["Error"] = "firm"; //for error message tailored to user
                return RedirectToAction("Error");
            }

            return View(firm);
        }
        public async Task<IActionResult> Firm_Finance(int id)
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Firm";
            //******************************************

            //routing from contact page ...
            if (id == 1 )
            {
                //in view...if data is not "" then display contact link in nav tree, otherwise show firm link ...
                ViewData["Contact"] = "x";
            }     

            var firm = await _context.Firm
            .Where(m => m.Title.Contains("Structured Finance Partner") 
            || m.LastName.Contains("Sedar") 
            || m.LastName.Contains("Arnold"))
                .OrderBy(m => m.LastName)
                .ToListAsync();

                foreach (var record in firm) {
                    if (record.Title == "Investment Partner")
                    {
                        record.Title = "Structured Finance Partner";
                    }
                }

            if (firm == null)
            {
                TempData["Error"] = "firm"; //for error message tailored to user
                return RedirectToAction("Error");
            }

            return View(firm);
        }
        public async Task<IActionResult> Firm_Operations(int id)
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Firm";
            //******************************************

            //routing from contact page ...
            if (id == 1 )
            {
                //in view...if data is not "" then display contact link in nav tree, otherwise show firm link ...
                ViewData["Contact"] = "x";
            }     

            var firm = await _context.Firm
                .Where(m => m.Title.Contains("Graphic") 
                || m.Title.Contains("Photo") 
                || m.Title.Contains("Logistics") 
                || m.Title.Contains("Production") 
                || m.Title.Contains("Technology"))
                .OrderBy(m => m.LastName)
                .ToListAsync();

        if (firm == null)
            {
                TempData["Error"] = "firm"; //for error message tailored to user
                return RedirectToAction("Error");
            }

            return View(firm);
        }
        public async Task<IActionResult> Input()
        {
            return View(await _context.Firm.ToListAsync());
        }

        // GET: Firm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (firm == null)
            {
                return NotFound();
            }

            return View(firm);
        }
         // GET: Firm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Firm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,FullName,Title,Email,Phone,Bio,College,Degree,ImgURL")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Input));
            }
            return View(firm);
        }

        // GET: Firm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firm.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }
            return View(firm);
        }

        // POST: Firm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,FullName,Title,Email,Phone,Bio,College,Degree,ImgURL")] Firm firm)
        {
            if (id != firm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmExists(firm.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Input));
            }
            return View(firm);
        }

        // GET: Firm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (firm == null)
            {
                return NotFound();
            }

            return View(firm);
        }

        // POST: Firm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firm = await _context.Firm.FindAsync(id);
            _context.Firm.Remove(firm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Input));
        }

        private bool FirmExists(int id)
        {
            return _context.Firm.Any(e => e.ID == id);
        }
    }
}
