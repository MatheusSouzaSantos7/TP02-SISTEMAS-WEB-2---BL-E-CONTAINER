// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.Containers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Container Container { get; set; } = new Container();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var c = await _context.Containers.FindAsync(id);
            if (c == null) return NotFound();
            Container = c;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var c = await _context.Containers.FindAsync(Container.Id);
            if (c != null)
            {
                _context.Containers.Remove(c);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
