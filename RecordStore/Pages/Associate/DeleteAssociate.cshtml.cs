using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Associate
{
    [BindProperties]
    public class DeleteAssociateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Associate Associate { get; set; }

        public DeleteAssociateModel(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public void OnGet(int id)
        {
            Associate = _db.Associate.Find(id);
        }

      
        public async Task<IActionResult> OnPost(Model.Associate associate)
        {
            var associateFromDb = _db.Associate.Find(associate.AssociateID);
            try
            {
                if (associateFromDb != null)
                {
                    _db.Associate.Remove(associateFromDb);
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
            return RedirectToPage("Associates");

        }
    }
}
