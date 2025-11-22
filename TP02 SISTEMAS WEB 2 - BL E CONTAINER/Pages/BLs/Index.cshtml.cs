// Matheus Angelo - CB3025489
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Pages.BLs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public IList<BL> BLs { get; set; } = new List<BL>();

        public async Task OnGetAsync()
        {
            BLs = await _context.BLs.Include(b => b.Containers).ToListAsync();
        }
    }
}
