using ExampleWebAPI01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebAPI01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandartController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StandartController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Standart> Get()
        {
            return _context.Standarts.ToList();
        }
    }
}
