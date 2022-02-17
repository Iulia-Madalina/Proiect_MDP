using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_MDP.Data;
using Proiect_MDP.Models;

namespace Proiect_MDP.Pages.Flowers
{
    public class CreateModel : FlowerCategoriesPageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public CreateModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            var flower = new Flower();
            flower.FlowerCategories = new List<FlowerCategory>();
            PopulateAssignedCategoryData(_context, flower);
            return Page();
        }

        [BindProperty]
        public Flower Flower { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newFlower = new Flower();
            if (selectedCategories != null)
            {
                newFlower.FlowerCategories = new List<FlowerCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FlowerCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFlower.FlowerCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Flower>(newFlower,"Flower",i => i.Name, i => i.Bio,i => i.Price, i => i.MaturingDate, i => i.SellerID))
            {
                _context.Flower.Add(newFlower);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newFlower);
            return Page();
        }
    }
}