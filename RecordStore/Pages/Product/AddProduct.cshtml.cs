using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Product Product { get; set; }
        public AddProductModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Model.Product product)
        {
           
            if (ModelState.IsValid) 
            {
                await _db.Product.AddAsync(product);
                await _db.SaveChangesAsync();
                TempData["success"] = "New product added Successfully";
                return RedirectToPage("ProductInventory");
            }

            return Page();
        }
    }
}
