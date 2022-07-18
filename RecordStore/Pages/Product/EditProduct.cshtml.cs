using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Product
{
    [BindProperties]
    public class EditProductModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Model.Product Product { get; set; }

        public EditProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public void OnGet(int id)
        {
            Product = _db.Product.Find(id);
        }

        
        public async Task<IActionResult> OnPost(Model.Product product)
        {

            _db.Product.Update(product);
            await _db.SaveChangesAsync();
            TempData["success"] = "associate Edited Successfully";

            return RedirectToPage("ProductInventory");
        }
    }
}
