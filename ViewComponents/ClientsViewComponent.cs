using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCI_Website_2018.Models;

namespace PCI_Website_2018.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly ClientsContext _contextC;

        public ClientsViewComponent(ClientsContext context)
        {
            _contextC = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
            
            var clients = from m in _contextC.ClientList
                 select m;
                //get clients dataset
                clients = clients.Where(s => s.CrfCompany.Contains(searchString));

                
            return View(await clients.ToListAsync());
        }
    }
}