using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            public int SortBy { get; set; } = 0;

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

        public void OnPostFind()
        {
            UserList = [.. _context.Users.Where(x => x.Id == Id)];

            Method = "Post with handler";
        }

        public void OnGet(InputModel input)
        {
            Input = input;

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
    }
}
