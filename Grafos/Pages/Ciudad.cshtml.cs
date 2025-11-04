using Grafos.Data;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList PaisesSelect { get; set; } = default;
        public List<Ciudad>ListaCiudades=new List<Ciudad>();
        public async Task OnGetAsync()
        {
            var listaPaises=await _context.Paises.ToListAsync();

            PaisesSelect= new SelectList(listaPaises,"PaisId","Nombre");
            ListaCiudades=await _context.Ciudades.ToListAsync();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                var listaPaises = await _context.Paises.ToListAsync();

                PaisesSelect = new SelectList(listaPaises, "PaisId", "Nombre");

                return Page();
            }

            _context.Ciudades.Add(NuevaCiudad);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }
    }
}
