using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Associate
{
    public class AssociatesModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public IEnumerable<Model.Associate> Associate { get; set; }
        public AssociatesModel(ApplicationDbContext db)
        {
            _db = db;

        }

        public void OnGet()
        {
            Associate = _db.Associate;
        }
       
    }
}
