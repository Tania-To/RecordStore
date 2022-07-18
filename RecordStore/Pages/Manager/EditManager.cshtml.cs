using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Manager
{
    [BindProperties]
    public class EditManagerModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Model.Manager Manager { get; set; }

        public EditManagerModel(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public void OnGet(int id)
        {
           Manager = _db.Manager.Find(id);
        }

      
        public async Task<IActionResult> OnPost(Model.Manager manager)
        {

            _db.Manager.Update(manager);
            await _db.SaveChangesAsync();
            TempData["success"] = "Manager Edited Successfully";

            return RedirectToPage("Managers");
        }
    }
}
