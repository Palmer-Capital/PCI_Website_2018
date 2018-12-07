using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCI_Website_2018.Models;
using Microsoft.AspNetCore.Http;

namespace PCI_Website_2018.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionsContext _context;

        public TransactionsController(TransactionsContext context)
        {
            _context = context; 
        }
        
        public WebsiteTransactions websiteTransactions { get; set; }

        // GET: Transactions
        public IActionResult Index(string id, string sortOrder, string currentFilter)
        {

            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************

            //for BUTTON active states – so know which Button
            ViewData["Type"] = "All";
            //******************************************

            var view = _context.WebsiteTransactions
            .OrderByDescending(m => m.WtrSizeNumeric);

            //if error accessing dataset ******************************************
            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }
            //**********************************************************************      

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";

            if (currentFilter == null)
            {
                return View(view.ToList());
            }                
            else if (currentFilter == "Property Name" || id == "name")
            {
                view = view.OrderBy(m => m.WtrName);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrName);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrName);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "City")
            {
                view = view.OrderBy(m => m.WtrCity);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrCity);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrCity);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "State")
            {
                view = view.OrderBy(m => m.WtrState);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrState);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrState);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Size")
            {
                view = view.OrderBy(m => m.WtrSizeNumeric);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrSizeNumeric);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrSizeNumeric);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Type")
            {
                view = view.OrderBy(m => m.WtrType);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrType);
                        break;
                    case "Order":
                        view = view.OrderBy(m => m.WtrType);
                        break;
                }    
                return View(view.ToList());
            }
            else {
                return View(view.ToList());
            }     
        }
        public IActionResult Office(string id, string sortOrder, string currentFilter)
        {
            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************

            //for BUTTON active states – so know which Button
            ViewData["Type"] = "Office";
            //******************************************

            var view = _context.WebsiteTransactions
            .Where(m => m.WtrType.Contains("Office"))
            .OrderByDescending(m => m.WtrSizeNumeric);

            //if error accessing data set ******************************************
            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }
            //**********************************************************************    

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";                

            if (currentFilter == null)
            {
                return View(view.ToList());
            }                
            else if (currentFilter == "Property Name" || id == "name")
            {
                view = view.OrderBy(m => m.WtrName);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrName);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrName);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "City")
            {
                view = view.OrderBy(m => m.WtrCity);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrCity);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrCity);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "State")
            {
                view = view.OrderBy(m => m.WtrState);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrState);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrState);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Size")
            {
                view = view.OrderBy(m => m.WtrSizeNumeric);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrSizeNumeric);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrSizeNumeric);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Type")
            {
                view = view.OrderBy(m => m.WtrType);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrType);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrType);
                        break;
                }    
                return View(view.ToList());
            }
            else {
                return View(view.ToList());
            }    
        }
        public IActionResult Industrial(string id, string sortOrder, string currentFilter)
        {
            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************

            //for BUTTON active states – so know which button
            ViewData["Type"] = "Industrial";
            //******************************************

            var view = _context.WebsiteTransactions
            .Where(m => m.WtrType.Contains("Industrial"))
            .OrderByDescending(m => m.WtrSizeNumeric);

            //if error accessing data set ******************************************
            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }
            //**********************************************************************     

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";                

            if (currentFilter == null)
            {
                return View(view.ToList());
            }                
            else if (currentFilter == "Property Name" || id == "name")
            {
                view = view.OrderBy(m => m.WtrName);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrName);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrName);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "City")
            {
                view = view.OrderBy(m => m.WtrCity);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrCity);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrCity);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "State")
            {
                view = view.OrderBy(m => m.WtrState);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrState);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrState);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Size")
            {
                view = view.OrderBy(m => m.WtrSizeNumeric);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrSizeNumeric);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrSizeNumeric);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Type")
            {
                view = view.OrderBy(m => m.WtrType);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrType);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrType);
                        break;
                }    
                return View(view.ToList());
            }
            else {
                return View(view.ToList());
            }    
        }
        public IActionResult Retail(string id, string sortOrder, string currentFilter)
        {
            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************

            //for BUTTON active states – so know which button
            ViewData["Type"] = "Retail";
            //******************************************
            
            var view = _context.WebsiteTransactions
            .Where(m => m.WtrType.Contains("Retail"))
            .OrderByDescending(m => m.WtrSizeNumeric);

            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }    

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";                

            //view.ForEach(m => m.ToString().Replace("&amp;", "").Replace("&gt;", ""));
            if (currentFilter == null)
            {
                return View(view.ToList());
            }                
            else if (currentFilter == "Property Name" || id == "name")
            {
                view = view.OrderBy(m => m.WtrName);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrName);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrName);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "City")
            {
                view = view.OrderBy(m => m.WtrCity);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrCity);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrCity);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "State")
            {
                view = view.OrderBy(m => m.WtrState);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrState);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrState);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Size")
            {
                view = view.OrderBy(m => m.WtrSizeNumeric);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrSizeNumeric);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrSizeNumeric);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Type")
            {
                view = view.OrderBy(m => m.WtrType);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrType);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrType);
                        break;
                }    
                return View(view.ToList());
            }
            else {
                return View(view.ToList());
            }      
        }
        public IActionResult Debt(string id, string sortOrder, string currentFilter)
        {
            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************

            //for BUTTON active states – so know which button
            ViewData["Type"] = "Debt";
            //******************************************
            
            var view = _context.WebsiteTransactions
            .Where(m => m.WtrType.Contains("Finance"))
            .OrderByDescending(m => m.WtrSizeNumeric);

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";       

            //if error accessing data set ******************************************
            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }
            //**********************************************************************    

            //view.ForEach(m => m.ToString().Replace("&amp;", "").Replace("&gt;", ""));
            if (currentFilter == null)
            {
                return View(view.ToList());
            }                
            else if  (currentFilter == "Property Name" || id == "name")
            {
                view = view.OrderBy(m => m.WtrName);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrName);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrName);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "City")
            {
                view = view.OrderBy(m => m.WtrCity);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrCity);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrCity);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "State")
            {
                view = view.OrderBy(m => m.WtrState);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrState);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrState);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Size")
            {
                view = view.OrderBy(m => m.WtrSizeNumeric);
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrSizeNumeric);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrSizeNumeric);
                        break;
                }    
                return View(view.ToList());
            }
            else if (currentFilter == "Type")
            {
                view = view.OrderBy(m => m.WtrType);

                if (view == null)
                {
                    return RedirectToAction("Error");
                }
                
                switch(sortOrder)
                {
                    case "Desc":
                        view = view.OrderByDescending(m => m.WtrType);
                        break;
                    case "Asc":
                        view = view.OrderBy(m => m.WtrType);
                        break;
                }    
                return View(view.ToList());
            }
            else {
                return View(view.ToList());
            }       
        }
        public IActionResult SearchTrans(string searchString, string sortOrder, string currentFilter, int id)
        {
            //for boolean in view - so we know it's a search result page - in order to use correct search form and sorting 
            ViewData["SearchSearch"] = true;
            
            //for NAVBAR active states – so know which page
            ViewData["Active"] = "Transactions";
            //******************************************
            
            //to show in search bar on searchresults ...
            ViewData["Search"] = searchString;
            //******************************************

            var view = from m in _context.WebsiteTransactions
                 select m;   

            //if error accessing data set ******************************************
            TempData["Error"] = "transactions"; //for error message tailored to user    
            if (!ModelState.IsValid || view == null)
            {
                return RedirectToAction("Error");
            }
            //**********************************************************************    

            switch(id)
            {
                case 8: // All (asp-route-id from View)
                    ViewData["Type"] = "All";
                break;
                case 9: // Office (asp-route-id from View)
                    view = view.Where(s => s.WtrType.Contains("Office"));
                    ViewData["Type"] = "Office";
                break;
                case 10: // Industrial (asp-route-id from View)
                    view = view.Where(s => s.WtrType.Contains("Industrial"));
                    ViewData["Type"] = "Industrial";
                break;
                case 11: // Retail (asp-route-id from View)
                    view = view.Where(s => s.WtrType.Contains("Retail"));
                    ViewData["Type"] = "Retail";
                break;
                case 12: // DEBT (asp-route-id from View)
                    view = view.Where(s => s.WtrType.Contains("Finance"));
                    ViewData["Type"] = "Debt";
                break;
            }

            ViewBag.OrderSortParm = sortOrder == "Asc" ? "Desc" : "Asc";

            if (!String.IsNullOrEmpty(searchString))
            {
                string searchStringSingle = " " + searchString + " ";  
                view = view.Where(s => s.WtrName.Contains(searchStringSingle)
                || s.WtrType.Contains(searchString)
                || s.WtrState.Contains(searchString)
                || s.WtrCity.Contains(searchString)
                || s.WtrDescription.Contains(searchStringSingle));

                ViewData["Count"] = view.Count();
                
                if (view.Any())
                {
                    if (!String.IsNullOrEmpty(currentFilter))
                    {
                        if (currentFilter == "Property Name")
                        {
                            view = view.OrderBy(m => m.WtrName);
                            switch(sortOrder)
                            {
                                case "Desc":
                                    view = view.OrderByDescending(m => m.WtrName);
                                    break;
                                case "Asc":
                                    view = view.OrderBy(m => m.WtrName);
                                    break;
                            }
                            if (id == 8) // All (asp-route-id from View)
                            {
                                return View("SearchAll", view.ToList());
                            }     
                            else if (id == 9) // Office (asp-route-id from View)
                            {
                                return View("SearchOffice", view.ToList());
                            }
                            else if (id == 10) // Industrial (asp-route-id from View)
                            {
                                return View("SearchIndustrial", view.ToList());
                            }
                            else if (id == 11) // Retail (asp-route-id from View)
                            {
                                return View("SearchRetail", view.ToList());
                            }
                            else if (id == 12) // Debt (asp-route-id from View)
                            {
                                return View("SearchDebt", view.ToList());
                            }
                            else
                            {
                                //no viable path taken                 
                                return RedirectToAction("Error");
                            }
                        }
                        else if (currentFilter == "City")
                        {
                            view = view.OrderBy(m => m.WtrCity);
                            switch(sortOrder)
                            {
                                case "Desc":
                                    view = view.OrderByDescending(m => m.WtrCity);
                                    break;
                                case "Asc":
                                    view = view.OrderBy(m => m.WtrCity);
                                    break;
                            }    
                            if (id == 8) // All (asp-route-id from View)
                            {
                                return View("SearchAll", view.ToList());
                            }
                            else if (id == 9) // Office (asp-route-id from View)
                            {
                                return View("SearchOffice", view.ToList());
                            }
                            else if (id == 10) // Industrial (asp-route-id from View)
                            {
                                return View("SearchIndustrial", view.ToList());
                            }
                            else if (id == 11) // Retail (asp-route-id from View)
                            {
                                return View("SearchRetail", view.ToList());
                            }
                            else if (id == 12) // Debt (asp-route-id from View)
                            {
                                return View("SearchDebt", view.ToList());
                            }
                            else
                            {
                                //no viable path taken                 
                                return RedirectToAction("Error");
                            }
                        }
                        else if (currentFilter == "State")
                        {
                            view = view.OrderBy(m => m.WtrState);
                            switch(sortOrder)
                            {
                                case "Desc":
                                    view = view.OrderByDescending(m => m.WtrState);
                                    break;
                                case "Asc":
                                    view = view.OrderBy(m => m.WtrState);
                                    break;
                            } 
                            if (id == 8) // All (asp-route-id from View)
                            {
                                return View("SearchAll", view.ToList());
                            }   
                            else if (id == 9) // Office (asp-route-id from View)
                            {
                                return View("SearchOffice", view.ToList());
                            }
                            else if (id == 10) // Industrial (asp-route-id from View)
                            {
                                return View("SearchIndustrial", view.ToList());
                            }
                            else if (id == 11) // Retail (asp-route-id from View)
                            {
                                return View("SearchRetail", view.ToList());
                            }
                            else if (id == 12) // Debt (asp-route-id from View)
                            {
                                return View("SearchDebt", view.ToList());
                            }
                            else
                            {
                                //no viable path taken                 
                                return RedirectToAction("Error");
                            }
                        }
                        else if (currentFilter == "Size")
                        {
                            view = view.OrderBy(m => m.WtrSizeNumeric);
                            switch(sortOrder)
                            {
                                case "Desc":
                                    view = view.OrderByDescending(m => m.WtrSizeNumeric);
                                    break;
                                case "Asc":
                                    view = view.OrderBy(m => m.WtrSizeNumeric);
                                    break;
                            }    
                            if (id == 8) // All (asp-route-id from View)
                            {
                                return View("SearchAll", view.ToList());
                            }
                            else if (id == 9) // Office (asp-route-id from View)
                            {
                                return View("SearchOffice", view.ToList());
                            }
                            else if (id == 10) // Industrial (asp-route-id from View)
                            {
                                return View("SearchIndustrial", view.ToList());
                            }
                            else if (id == 11) // Retail (asp-route-id from View)
                            {
                                return View("SearchRetail", view.ToList());
                            }
                            else if (id == 12) // Debt (asp-route-id from View)
                            {
                                return View("SearchDebt", view.ToList());
                            }
                            else
                            {
                                //no viable path taken                 
                                return RedirectToAction("Error");
                            }
                        }
                        else if (currentFilter == "Type")
                        {
                            view = view.OrderBy(m => m.WtrType);
                            switch(sortOrder)
                            {
                                case "Desc":
                                    view = view.OrderByDescending(m => m.WtrType);
                                    break;
                                case "Asc":
                                    view = view.OrderBy(m => m.WtrType);
                                    break;
                            }    
                            if (id == 8) // All (asp-route-id from View)
                            {
                                return View("SearchAll", view.ToList());
                            }
                            else if (id == 9) // Office (asp-route-id from View)
                            {
                                return View("SearchOffice", view.ToList());
                            }
                            else if (id == 10) // Industrial (asp-route-id from View)
                            {
                                return View("SearchIndustrial", view.ToList());
                            }
                            else if (id == 11) // Retail (asp-route-id from View)
                            {
                                return View("SearchRetail", view.ToList());
                            }
                            else if (id == 12) // Debt (asp-route-id from View)
                            {
                                return View("SearchDebt", view.ToList());
                            }
                            else
                            {
                                //no viable path taken                 
                                return RedirectToAction("Error");
                            }
                        }
                        else {
                            //no viable path taken                 
                            return RedirectToAction("Error");
                        }
                    } 
                    else
                    {
                        if (id == 8) // All (asp-route-id from View)
                        {
                            return View("SearchAll", view.OrderByDescending(s => s.WtrSizeNumeric).ToList());
                        }
                        else if (id == 9) // Office (asp-route-id from View)
                        {
                            return View("SearchOffice", view.OrderByDescending(s => s.WtrSizeNumeric).ToList());
                        }
                        else if (id == 10) // Industrial (asp-route-id from View)
                        {
                            return View("SearchIndustrial", view.OrderByDescending(s => s.WtrSizeNumeric).ToList());
                        }
                        else if (id == 11) // Retail (asp-route-id from View)
                        {
                            return View("SearchRetail", view.OrderByDescending(s => s.WtrSizeNumeric).ToList());
                        }
                        else if (id == 12) // DEBT (asp-route-id from View)
                        {
                            return View("SearchDebt", view.OrderByDescending(s => s.WtrSizeNumeric).ToList());
                        }
                        else 
                        {
                            //no viable path taken                                 
                            return RedirectToAction("Error");
                        }
                    }
                }
                else
                {
                    //for boolean in view - in order use correct search form 
                    ViewData["Null"] = true;
                    return View("_SearchTransNull");
                }
            }
            else 
            {
                //for boolean in view - in order use correct search form 
                ViewData["Null"] = true;
                return View("_SearchTransNull");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var tData = TempData["Error"];
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
