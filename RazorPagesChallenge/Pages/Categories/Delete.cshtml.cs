using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesChallenge.Data;
using RazorPagesChallenge.Model;

namespace RazorPagesChallenge.Pages.Categories;
public class DeleteModel : PageModel
{
    private readonly AppDbContext _db;
    [BindProperty]
    public Category Category { get; set; }

    public DeleteModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet(int id)
    {
        Category = _db.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _db.Category.Remove(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category Removed Successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
