using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP.Data;
using Proiect_MDP.Models;

namespace Proiect_MDP.Pages.Flowers
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public DetailsModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public Flower Flower { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flower = await _context.Flower.FirstOrDefaultAsync(m => m.ID == id);

            if (Flower == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
