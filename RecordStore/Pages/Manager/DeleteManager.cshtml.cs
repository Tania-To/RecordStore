using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Manager
{
    [BindProperties]
    public class DeleteManagerModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Manager Manager { get; set; }

        public DeleteManagerModel(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public void OnGet(int id)
        {
            Manager = _db.Manager.Find(id);
        }

       
        public async Task<IActionResult> OnPost(Model.Manager manager)
        {
            var managerFromDb = _db.Manager.Find(manager.ManagerID);
            try
            {
                if (managerFromDb != null)
                {
                    _db.Manager.Remove(managerFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Associate record deleted Successfully";
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Sorry, we are unable to process your request.";
            }
            return RedirectToPage("Managers");

        }
    }
}
