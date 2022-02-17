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
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public IndexModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public IList<Flower> Flower { get;set; }
        public FlowerData FlowerD { get; set; }
        public int FlowerID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FlowerD = new FlowerData();

            FlowerD.Flowers = await _context.Flower.Include(b => b.Seller).Include(b => b.FlowerCategories).ThenInclude(b => b.Category).AsNoTracking().OrderBy(b => b.Name).ToListAsync();
            if (id != null)
            {
                FlowerID = id.Value;
                Flower flower = FlowerD.Flowers
                .Where(i => i.ID == id.Value).Single();
                FlowerD.Categories = flower.FlowerCategories.Select(s => s.Category);
            }
        }
    }
}
