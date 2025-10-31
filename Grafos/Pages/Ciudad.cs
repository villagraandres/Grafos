using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Grafos.Models;

namespace Grafos.Pages
{
    public class CiudadModel:PageModel
    {
        [BindProperty]
        public Ciudad NuevaCiudad {  get; set; }=new Ciudad();

        public void OnGet()
        {

        }
        public void OnPost() { 
            Console.WriteLine(NuevaCiudad.Nombre);
        }
    }
}
