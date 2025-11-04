using Grafos.Data;
using Grafos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grafos.Pages
{
    public class CarreterasModel : PageModel
    {

        public readonly AppDbContext _context;
        public CarreterasModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Carretera NuevaCarretera { get; set; } = new Carretera();

        public SelectList OrigenSelect { get; set; } = new SelectList(Enumerable.Empty<Ciudad>(), "CiudadId", "Nombre");
        public SelectList DestinoSelect { get; set; } = new SelectList(Enumerable.Empty<Ciudad>(), "CiudadId", "Nombre");
        public SelectList TipoSelect { get; set; } = new SelectList(Enumerable.Empty<TipoCarretera>(), "TipoCarreteraId", "Nombre");

        public IList<Carretera> ListaCarreteras { get; set; } = new List<Carretera>();

        private async Task LoadSelectsAsync()
        {
            var ciudades = await _context.Ciudades
                                         .OrderBy(c => c.Nombre)
                                         .ToListAsync();

            OrigenSelect = new SelectList(ciudades, "CiudadId", "Nombre");
            DestinoSelect = new SelectList(ciudades, "CiudadId", "Nombre");

            var tipos = await _context.TiposCarretera
                                      .OrderBy(t => t.Nombre)
                                      .ToListAsync();
            TipoSelect = new SelectList(tipos, "TipoCarreteraId", "Nombre");
        }

        public async Task OnGetAsync()
        {
            await LoadSelectsAsync();


            ListaCarreteras = await _context.Carreteras
                                           .Include(c => c.CiudadOrigen)
                                           .Include(c => c.CiudadDestino)
                                           .Include(c => c.Tipo)
                                           .OrderBy(c => c.CarreteraId)
                                           .ToListAsync();
        }

        public async Task<JsonResult> OnGetGraphAsync()
        {
            var carreteras = await _context.Carreteras
                .AsNoTracking()
                .Include(c => c.CiudadOrigen)
                .Include(c => c.CiudadDestino)
                .Include(c => c.Tipo)
                .ToListAsync();

            var nodes = carreteras
                .SelectMany(c => new[] { c.CiudadOrigen, c.CiudadDestino })
                .Where(ci => ci != null)
                .DistinctBy(ci => ci!.CiudadId)
                .Select(ci => new
                {
                    id = ci!.CiudadId,
                    label = ci!.Nombre
                })
                .ToList();

            var edges = carreteras
                .Select(c => new
                {
                    id = c.CarreteraId,
                    from = c.CiudadOrigenId,
                    to = c.CiudadDestinoId,
                    label = $"{c.DistanciaKm:N2} km"
                })
                .ToList();

            return new JsonResult(new { nodes, edges });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectsAsync();
                ListaCarreteras = await _context.Carreteras
                                               .Include(c => c.CiudadOrigen)
                                               .Include(c => c.CiudadDestino)
                                               .Include(c => c.Tipo)
                                               .OrderBy(c => c.CarreteraId)
                                               .ToListAsync();
                return Page();
            }

            _context.Carreteras.Add(NuevaCarretera);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
