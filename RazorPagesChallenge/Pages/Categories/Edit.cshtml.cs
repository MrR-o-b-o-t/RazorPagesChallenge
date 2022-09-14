using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesChallenge.Data;
using RazorPagesChallenge.Model;

namespace RazorPagesChallenge.Pages.Categories;
public class EditModel : PageModel
{
    private readonly AppDbContext _db;
    [BindProperty]
    public Category Category { get; set; }

    public EditModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet(int id)
    {
        Category = _db.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if(Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "Name and Display Order cannot match.");
        }
        if (ModelState.IsValid)
        {
            _db.Category.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category Updated Successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
