// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.Containers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public Container Container { get; set; } = new Container();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var c = await _context.Containers.Include(c => c.BL).FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return NotFound();
            Container = c;
            return Page();
        }
    }
}
