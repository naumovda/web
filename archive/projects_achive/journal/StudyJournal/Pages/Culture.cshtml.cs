using StudyJournal.Data;
using StudyJournal.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyJournal.Pages
{
    public class CultureModel : PageModel
    {
        public CultureModel()
        {
        }

        public IActionResult OnGet(string url)
        {
            if (url != null) 
            {
                return Redirect(url);
            }

            return Redirect("/");
        }

        public Task<IActionResult> OnGetRussian(string url)
        {
            return SetCulture("ru", url);
        }

        public Task<IActionResult> OnGetEnglish(string url)
        {
            return SetCulture("en", url);
        }

        public async Task<IActionResult> SetCulture(string culture, string returnUrl)
        {
            var options = new CookieOptions { 
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                options
            );

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return Redirect("/");
        }
    }
}