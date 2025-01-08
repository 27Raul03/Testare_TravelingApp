using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Testare_TravelingApp.Pages
{
    public class ErrorModel : PageModel
    {
        [BindProperty]
        public string ErrorMessage { get; set; } = "An unknown error occurred.";

        public void OnGet(string? errorMessage = null)
        {
            ErrorMessage = errorMessage ?? "An unknown error occurred.";
        }
    }
}
