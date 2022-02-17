using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP.Data;
using Proiect_MDP.Models;

namespace Proiect_MDP.Pages.Flowers
{
    public class EditModel : FlowerCategoriesPageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public EditModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flower Flower { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerToUpdate = await _context.Flower.Include(i => i.Seller).Include(i => i.FlowerCategories).ThenInclude(i => i.Category).FirstOrDefaultAsync(s => s.ID == id);
            if (flowerToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Flower>(flowerToUpdate,"Flower",
            i => i.Name, i => i.Bio,
            i => i.Price, i => i.MaturingDate, i => i.Seller))
            {
                UpdateFlowerCategories(_context, selectedCategories, flowerToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateFlowerCategories(_context, selectedCategories, flowerToUpdate);
            PopulateAssignedCategoryData(_context, flowerToUpdate);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Flower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerExists(Flower.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlowerExists(int id)
        {
            return _context.Flower.Any(e => e.ID == id);
        }
    }
}
