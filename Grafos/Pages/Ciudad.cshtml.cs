using Grafos.Data;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace Grafos.Pages
{
    public class CiudadModel:PageModel
    {

        private readonly AppDbContext _context;
        public CiudadModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]

        

        public Ciudad NuevaCiudad {  get; set; }=new Ciudad();
        

        public async Task OnGetAsync()
        {
            var listaPaises=await _context.Ciudades.ToListAsync();

        }
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Ciudades.Add(NuevaCiudad);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }
    }
}
