using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCI_Website_2018.Models;

namespace PCI_Website_2018.ViewComponents
{
    public class ClientsReferencesViewComponent : ViewComponent
    {
        private readonly ClientsReferencesContext _contextR;

        public ClientsReferencesViewComponent(ClientsReferencesContext context)
        {
            _contextR = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
            
            var references = from m in _contextR.ClientReferences
                 select m;
                //get clients dataset
                references = references.Where(s => s.RefCompany.Contains(searchString)
                || s.RefFullname.Contains(searchString));

                
            return View(await references.ToListAsync());
        }
    }
}