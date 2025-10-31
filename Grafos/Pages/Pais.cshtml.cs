using Grafos.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Paises.Add(NuevoPais);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
