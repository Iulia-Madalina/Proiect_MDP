using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP.Data;
using Proiect_MDP.Models;

namespace Proiect_MDP.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP.Data.Proiect_MDPContext _context;

        public IndexModel(Proiect_MDP.Data.Proiect_MDPContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
