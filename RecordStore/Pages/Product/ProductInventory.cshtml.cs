using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecordStore.Data;

namespace RecordStore.Pages.Product;

public class ProductInventoryModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Product> Product { get; set; }
    public ProductInventoryModel(ApplicationDbContext db)
    {
        _db = db;
       
    }

    public void OnGet()
    {
        Product = _db.Product;
    }
}
