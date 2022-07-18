using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Product
{
    [BindProperties]
    public class DeleteProductModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Product Product { get; set; }

        public DeleteProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public void OnGet(int id)
        {
           Product = _db.Product.Find(id);
        }

        
        public async Task<IActionResult> OnPost(Model.Product product)
        {
            var productFromDb = _db.Product.Find(product.ProductID);
            try
            {
                if (productFromDb != null)
                {
                    _db.Product.Remove(productFromDb);
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
            return RedirectToPage("ProductInventory");

        }
    }
}
