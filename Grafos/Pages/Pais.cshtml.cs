
using Grafos.Data;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace Grafos.Pages
{
    public class PaisModel : PageModel
    {


        private readonly AppDbContext _context;

        public PaisModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Pais NuevoPais { get; set; } = new Pais();
        public List<Pais> ListaPaises { get; set; } = new List<Pais>();

        public async Task OnGetAsync()
        {
            ListaPaises = await _context.Paises.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Paises.Add(NuevoPais);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
