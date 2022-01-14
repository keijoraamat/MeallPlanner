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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.DAL.AppDbContext _context;

        public DetailsModel(WebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IngredientInCategory IngredientInCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IngredientInCategory = await _context.IngredientInCategories
                .Include(i => i.Category)
                .Include(i => i.Ingredient).FirstOrDefaultAsync(m => m.Id == id);

            if (IngredientInCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
