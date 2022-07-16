using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Manager
{
    public class ManagersModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Model.Manager> Manager { get; set; }
        public ManagersModel(ApplicationDbContext db)
        {
            _db = db;

        }

        public void OnGet()
        {
            Manager = _db.Manager;
        }
    }
}
