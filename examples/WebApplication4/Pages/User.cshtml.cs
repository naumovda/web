using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class UserModel : PageModel
    {
        public class InputModel
        {
            public string Name { get; set; } = null!;
            public int AgeStart { get; set; } = MIN_AGE;
            public int AgeEnd { get; set; } = MAX_AGE;
            public string[]? Tags { get; set; }

            public int CurrentPage { get; set; } = 0;

            public int SortBy { get; set; } = 1;

            public bool SortAsc { get; set; } = true;

        }
        public static int PAGE_SIZE = 2;
        public static int PAGE_COUNT = 2;

        public static int MIN_AGE = 0;
        public static int MAX_AGE = 9999;

        public readonly ApplicationContext _context;

        public List<User> UserList;
        public int TotalCount { get; set; }
        public int FirstPage
        {
            get
            {
                int v = Input.CurrentPage - PAGE_COUNT;
                if (v < 0)
                    return 0;
                return v;
            }
        }
        public int LastPage
        {
            get
            {
                int v = TotalCount / PAGE_SIZE;

                if (TotalCount % PAGE_SIZE != 0)
                    v++;

                return v;
            }
        }

        public bool DisablePrev => Input.CurrentPage == 0;
        public bool DisableNext => Input.CurrentPage == LastPage - 1;

        public InputModel Input { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public string Method { get; set; } = string.Empty;

        public bool HideFilter => HideName && HideAge;
        public bool HideAge => Input.AgeStart == MIN_AGE && Input.AgeEnd == MAX_AGE;
        public bool HideName => Input.Name == null;

        public UserModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGetFind()
        {
            UserList = [.. _context.Users.Where(x => x.Id == Id)];

            Method = "Get with handler";
        }
        public void OnPost()
        {
            UserList = [.. _context.Users.Where(x => x.Id == Id)];

            Method = "Post without handler!";
        }

        public IActionResult OnPostFind(InputModel input)
        {
            Response.Cookies.Append("UserName", input.Name ?? "",
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            Response.Cookies.Append("AgeStart", input.AgeStart.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            Response.Cookies.Append("AgeEnd", input.AgeEnd.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            return Redirect("/User");
        }

        public IActionResult OnPostSort(InputModel input)
        {
            Response.Cookies.Append("SortBy", input.SortBy.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            Response.Cookies.Append("SortAsc", input.SortAsc.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            return Redirect("/User");
        }

        public void OnGet(InputModel input)
        {
            Input = input;

            if (Request.Cookies.TryGetValue("UserName", out string? s))
            {
                Input.Name = s ?? string.Empty;
            }

            if (Request.Cookies.TryGetValue("AgeStart", out s))
            {
                if (int.TryParse(s, out int value))
                {
                    Input.AgeStart = value;
                }
            }

            if (Request.Cookies.TryGetValue("AgeEnd", out s))
            {
                if (int.TryParse(s, out int value))
                {
                    Input.AgeEnd = value;
                }
            }

            if (Request.Cookies.TryGetValue("SortBy", out s))
            {
                if (int.TryParse(s, out int value))
                {
                    Input.SortBy = value;
                }
            }

            if (Request.Cookies.TryGetValue("SortAsc", out s))
            {
                if (bool.TryParse(s, out bool value))
                {
                    Input.SortAsc = value;
                }
            }

            if (Input.Name != null)
            {
                UserList = _context.Users
                    .Where(x => x.Name != null && x.Name.Contains(Input.Name))
                    .ToList();
            }
            else
            {
                UserList = _context.Users.ToList();
            }

            UserList = UserList
                .Where(x => x.Age >= Input.AgeStart && x.Age <= Input.AgeEnd)
                .ToList();

            switch (Input.SortBy)
            {
                case 0:
                    UserList = UserList.OrderBy(x => x.Id).ToList();
                    break;
                case 1:
                    UserList = UserList.OrderBy(x => x.Name).ToList();
                    break;
                case 2:
                    UserList = UserList.OrderBy(x => x.Age).ToList();
                    break;
            }

            if (!Input.SortAsc)
            {
                UserList.Reverse();
            }

            TotalCount = UserList.Count;

            UserList = UserList
                .Skip(Input.CurrentPage * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }

        public IActionResult OnGetModalDelete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return new PartialViewResult
            {
                ViewName = "_UserDeleteModal",
                ViewData = new ViewDataDictionary<User>(ViewData, user)
            };
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id) 
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Redirect("/User");
        }

    }
}
