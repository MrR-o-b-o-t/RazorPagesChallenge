using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesChallenge.Data;
using RazorPagesChallenge.Model;

namespace RazorPagesChallenge.Pages.Categories;
public class CreateModel : PageModel
{
    private readonly AppDbContext _db;
    [BindProperty]
    public Category Category { get; set; }

    public CreateModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if(Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "Name and Display Order cannot match.");
        }
        if (ModelState.IsValid)
        {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category Created Successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
