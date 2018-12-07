using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCI_Website_2018.Models;

namespace PCI_Website_2018.ViewComponents
{
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly TransactionsContext _contextT;

        public TransactionsViewComponent(TransactionsContext context)
        {
            _contextT = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
            string searchStringSingle = " " + searchString + " ";
                 var transactions = from m in _contextT.WebsiteTransactions
                 select m;
                //get transactions dataset
                transactions = transactions.Where(s => s.WtrName.Contains(searchStringSingle)
                || s.WtrType.Contains(searchString)
                || s.WtrState.Contains(searchString)
                || s.WtrCity.Contains(searchString)
                || s.WtrDescription.Contains(searchStringSingle));

                
            return View(await transactions.ToListAsync());
        }
    }
}