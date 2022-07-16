using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Manager
{
    public class AddManagerModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Manager Manager { get; set; }
        public AddManagerModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Model.Manager manager)
        {

            if (ModelState.IsValid) //if db error occurs, then reload the page
            {
                await _db.Manager.AddAsync(manager);
                await _db.SaveChangesAsync();
                TempData["success"] = "New product added Successfully";
                return RedirectToPage("Managers");
            }

            return Page();
        }
    }
}
