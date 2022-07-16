using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Associate;

public class AddAssociateModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public Model.Associate Associate { get; set; }
    public AddAssociateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPost(Model.Associate associate)
    {

        if (ModelState.IsValid) //if db error occurs, then reload the page
        {
            await _db.Associate.AddAsync(associate);
            await _db.SaveChangesAsync();
            TempData["success"] = "New product added Successfully";
            return RedirectToPage("Associates");
        }

        return Page();
    }
}

