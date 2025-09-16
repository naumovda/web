<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationContext _context;

        public List<User> Users { get; private set; } = new();

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Users = _context.Users.AsNoTracking().ToList();
        }
    }
}
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationContext _context;

        public List<User> Users { get; private set; } = new();

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Users = _context.Users.AsNoTracking().ToList();
        }
    }
}
>>>>>>> d05455dd19aae7050710ca60caa526629780a968
