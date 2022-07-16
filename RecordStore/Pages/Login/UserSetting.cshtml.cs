using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Login
{
    public class UserSettingModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Model.Associate Associate { get; set; }

        public UserSettingModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Associate = _db.Associate.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Associate associate)
        {
            if (ModelState.IsValid)
            {
                _db.Associate.Update(associate);
                await _db.SaveChangesAsync();
                TempData["success"] = "User edited successfully";
                return Page();
            }
            return Page();

        }
    }
}

