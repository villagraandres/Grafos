using Grafos.Data;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Grafos.Pages
{
    public class TipoCarreteraModel : PageModel
    {
        private readonly AppDbContext _context;
        public TipoCarreteraModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoCarretera NuevaTipo { get; set; } = new TipoCarretera();

        public IList<TipoCarretera> ListaTipos { get; set; } = new List<TipoCarretera>();

        public async Task OnGetAsync()
        {
            ListaTipos = await _context.TiposCarretera
                                       .OrderBy(t => t.Nombre)
                                       .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.TiposCarretera.Add(NuevaTipo);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
