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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public DetailsModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public Seller Seller { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = await _context.Seller.FirstOrDefaultAsync(m => m.ID == id);

            if (Seller == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
