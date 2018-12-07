using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCI_Website_2018.Models;

namespace PCI_Website_2018.ViewComponents
{
    public class FirmViewComponent : ViewComponent
    {
        private readonly FirmContext _contextF;

        public FirmViewComponent(FirmContext context)
        {
            _contextF = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
  
                var firm = from m in _contextF.Firm
                select m;

                searchString = searchString.ToLower();
                string searchStringSingle = " " + searchString + " ";
                //get firm dataset
                firm = firm.Where(s => s.Title.ToLower().Contains(searchString)
                || s.FirstName.ToLower().Contains(searchString)
                || s.LastName.ToLower().Contains(searchString)
                || s.FullName.ToLower().Contains(searchString)
                || s.Email.ToLower().Contains(searchString)
                || s.Bio.ToLower().Contains(searchStringSingle));

                
            return View(await firm.ToListAsync());
        }
    }
}