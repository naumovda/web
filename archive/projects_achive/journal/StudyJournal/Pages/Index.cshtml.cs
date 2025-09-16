using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using StudyJournal.Services;

namespace StudyJournal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStringLocalizer<IndexModel> _localizer;

        public string Message { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, 
            ITimeService timeService,
            IStringLocalizer<IndexModel> localizer)
        {
            _logger = logger;
            _localizer = localizer;

            Message = $"Time: {timeService.Time}";
        }

        public void OnGet([FromServices] ITimeService timeService)
        {

        }

        public void OnPost()
        {
            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            Message = $"Time: {timeService?.Time}";
        }

    }
}
