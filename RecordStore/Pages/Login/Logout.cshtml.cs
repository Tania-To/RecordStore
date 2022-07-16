using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecordStore.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");

            return RedirectToPage("/Index");
        }
    }
}
