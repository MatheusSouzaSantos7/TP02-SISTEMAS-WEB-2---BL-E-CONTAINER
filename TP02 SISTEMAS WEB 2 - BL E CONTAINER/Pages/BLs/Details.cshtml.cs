// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.BLs
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public BL BL { get; set; } = new BL();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var b = await _context.BLs.Include(b => b.Containers).FirstOrDefaultAsync(x => x.Id == id);
            if (b == null) return NotFound();
            BL = b;
            return Page();
        }
    }
}
