using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP.Data;
using Proiect_MDP.Models;

namespace Proiect_MDP.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public IndexModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; }

        public async Task OnGetAsync()
        {
            Seller = await _context.Seller.ToListAsync();
        }
    }
}
