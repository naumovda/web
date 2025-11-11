using ExampleWebAPI01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebAPI01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstrateTypesController : Controller
    {
        // GET: api/substrateTypes
        [HttpGet]
        public IEnumerable<SubstrateType> Get(CoatingSurfaceEnum e)
        {
            return [];
        }

        // GET api/substrateTypes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/substrateTypes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/substrateTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/substrateTypes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // DELETE api/substrateTypes
        [HttpDelete("")]
        public void DeleteAll()
        {
        }
    }
}
