using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Associate
{
    [BindProperties]
    public class EditAssociateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Associate Associate { get; set; }

        public EditAssociateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
          Associate = _db.Associate.Find(id);
        }

        
        public async Task<IActionResult> OnPost(Model.Associate associate)
        {
            
                _db.Associate.Update(associate);
                await _db.SaveChangesAsync();
                TempData["success"] = "associate Edited Successfully";
           
            return RedirectToPage("Associates");
        }
    }
}
