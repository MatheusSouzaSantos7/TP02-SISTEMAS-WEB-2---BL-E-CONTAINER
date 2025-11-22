// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.Containers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Container Container { get; set; } = new Container();

        public SelectList BLOptions { get; set; } = default!;

        public async Task OnGetAsync(int? blId)
        {
            var bls = await _context.BLs.ToListAsync();
            BLOptions = new SelectList(bls, "Id", "Numero");
            if (blId.HasValue) Container.BLId = blId.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Containers.Add(Container);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
