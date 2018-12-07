using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCI_Website_2018.Models;


namespace PCI_Website_2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientsContext _contextC;
        private readonly ClientsReferencesContext _contextR;
        private readonly FirmContext _contextF;
        private readonly TransactionsContext _contextT;

        public HomeController(ClientsContext contextC, ClientsReferencesContext contextR, FirmContext contextF, TransactionsContext contextT, ILogger<HomeController> logger)
        {
            _contextC = contextC;
            _contextF = contextF;
            _contextT = contextT; 
            _contextR = contextR; 
            _logger = logger;
        }
        
        public ClientList clientList { get; set; }
        public ClientReferences clientReferences { get; set; }

        public string AssemblyVersion { get; set; }
 


        public IActionResult Index()
        {
            return View();  
        }
        public IActionResult About()
        {
            //for nav active states – so know which page
            ViewData["Active"] = "About";
            //******************************************
            return View();
        }
        public IActionResult Clients()
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Clients";
            //******************************************

            var clients = _contextC.ClientList
            .OrderBy(m => m.CrfCompany);

            TempData["Error"] = "clients"; //for error message tailored to user
            if (clients == null)
            {
                return RedirectToAction("Error");
            }

            return View(clients.ToList());
        }
        public IActionResult References()
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Clients";
            //******************************************

            var references = _contextR.ClientReferences
            .OrderBy(m => m.RefCompany);

            TempData["Error"] = "references"; //for error message tailored to user

            if (references == null)
            {
                return RedirectToAction("Error");
            }

            return View(references.ToList());
        }
        public IActionResult Search(string searchString, string sortOrder, string currentFilter)
        {
            // IQueryable<string> clientQuery = from m in _contextC.ClientList
            //                     orderby m.CrfCompany
            //                     select m.CrfCompany;

            ViewData["Search"] = searchString;
            
            string searchStringSingle = " " + searchString + " ";

            var transactions = from m in _contextT.WebsiteTransactions
                 select m;                    

            var firm = from m in _contextF.Firm
                 select m;

            var clients = from m in _contextC.ClientList
                 select m;

            var references = from m in _contextR.ClientReferences
                 select m;

            if (transactions == null || firm == null || clients == null || references == null) // in case problem accessing database
            {
                return RedirectToAction("Error");
            }

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";

            if(!String.IsNullOrEmpty(searchString))
            {

                //get clients dataset
                clients = clients.Where(s => s.CrfCompany.Contains(searchString));
                
                //get references dataset
                references = references.Where(s => s.RefCompany.Contains(searchString)
                || s.RefFullname.Contains(searchString));
                
                //get transactions dataset
                transactions = transactions.Where(s => s.WtrName.Contains(searchStringSingle)
                || s.WtrType.Contains(searchString)
                || s.WtrState.Contains(searchString)
                || s.WtrCity.Contains(searchString)
                || s.WtrDescription.Contains(searchStringSingle));

                
                searchString = searchString.ToLower();  
                searchStringSingle = " " + searchString + " ";             
                //get firm dataset - need to search lowercase becasue SQLite table is case sensitive - bad for searches
                firm = firm.Where(s => s.Title.ToLower().Contains(searchString)
                || s.FirstName.ToLower().Contains(searchString)
                || s.LastName.ToLower().Contains(searchString)
                || s.FullName.ToLower().Contains(searchString)
                || s.Email.ToLower().Contains(searchString)
                || s.Bio.ToLower().Contains(searchStringSingle));
                
                if (firm.Any() || clients.Any() || references.Any() || transactions.Any())
                {
                    //get counts and datasets (again) in view component classes...
                    ViewData["Count"] = firm.Count() + clients.Count() + references.Count() +  transactions.Count();
                    ViewData["FirmCount"] = firm.Count();
                    ViewData["ClientsCount"] = clients.Count();
                    ViewData["RefCount"] = references.Count();
                    ViewData["TransactionsCount"] = transactions.Count();

                    return View("_Search");
                }

                else 
                {
                    return View("_SearchNull");
                }
            }
            else{
                return View("_SearchNull");
            }
        }
        public IActionResult Contact()
        {
            //for nav active states – so know which page
            ViewData["Active"] = "Contact";
            //******************************************
            return View();
        }
        public IActionResult TeamTravel()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        private readonly ILogger<HomeController> _logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var tData = TempData["Error"];
            _logger.LogInformation($"Error Logged: {HttpContext.TraceIdentifier}");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
