using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesChallenge.Data;
using RazorPagesChallenge.Model;

namespace RazorPagesChallenge.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
