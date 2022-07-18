using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;

namespace RecordStore.Pages.Login
{
  
    public class LoginModel : PageModel
    {
        [BindProperty]
       public Credential Credential { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            if (Credential.Email== "admin@mrc.com" && Credential.Password =="password")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mrc.com"),
                    new Claim("HR", "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            // Initialization.  
            try
            {
                using (SqlConnection connection = new SqlConnection("Server =.\\sqlexpress; Database = MentalRecords; Trusted_Connection = True"))
                {
                    connection.Open();
                    
                    String myCommand = "SELECT* FROM Manager WHERE Email = @Email AND Password = @Password ";
                    SqlCommand cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar,200).Value = Credential.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Value = Credential.Password;
                    int idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        var claims = new List<Claim> {
                            new Claim(ClaimTypes.Name, Credential.Email),
                           new Claim(ClaimTypes.Email, Credential.Email),
                            new Claim("UserManager", "Manager"),
                            new Claim("UserId", idNumber.ToString())
                    };

                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                        return RedirectToPage("/Index");
                    }
                    
                    myCommand = "SELECT* FROM Associate WHERE Email = @Email AND Password = @Password ";
                    cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = Credential.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Value = Credential.Password;
                    idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        var claims = new List<Claim> {
                             new Claim(ClaimTypes.Name, Credential.Email),
                           new Claim(ClaimTypes.Email, Credential.Email),
                            new Claim("UserAssociate", "Associate"),
                            new Claim("UserId", idNumber.ToString())
                        };

                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                        return RedirectToPage("/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error. Unable to process request. try again later",ex.Message);
            }

            ModelState.AddModelError("", "Incorrect Email Address or Password");
            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    
    
    
}
