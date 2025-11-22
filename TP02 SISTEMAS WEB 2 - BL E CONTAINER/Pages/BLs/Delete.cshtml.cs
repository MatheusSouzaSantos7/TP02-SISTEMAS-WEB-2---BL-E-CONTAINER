// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.BLs
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public BL BL { get; set; } = new BL();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var b = await _context.BLs.FindAsync(id);
            if (b == null) return NotFound();
            BL = b;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var b = await _context.BLs.FindAsync(BL.Id);
            if (b != null)
            {
                _context.BLs.Remove(b);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
