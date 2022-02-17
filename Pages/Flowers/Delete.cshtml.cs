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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public DeleteModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flower = await _context.Flower.FindAsync(id);

            if (Flower != null)
            {
                _context.Flower.Remove(Flower);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
