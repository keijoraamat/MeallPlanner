#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Domain;

namespace WebApp.Pages.IngredientInCategories
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.DAL.AppDbContext _context;

        public IndexModel(WebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<IngredientInCategory> IngredientInCategory { get;set; }

        public async Task OnGetAsync()
        {
            IngredientInCategory = await _context.IngredientInCategories
                .Include(i => i.Category)
                .Include(i => i.Ingredient).ToListAsync();
        }
    }
}
