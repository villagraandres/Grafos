using Microsoft.AspNetCore.Mvc.RazorPages;
using Grafos.Data;

namespace Grafos.Pages
{
    public class IndexModel:PageModel
    {

        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        
    }
}
