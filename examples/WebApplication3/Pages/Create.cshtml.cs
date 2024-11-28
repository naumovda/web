using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public User Person { get; set; } = new();

        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Users.Add(Person);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
