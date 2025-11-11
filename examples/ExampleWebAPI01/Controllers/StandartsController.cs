using Asp.Versioning;
using ExampleWebAPI01.Models;
using ExampleWebAPI01.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExampleWebAPI01.Controllers
{
    [Route("[controller]")]
    public class StandartsController : Controller
    {
        private StandartService _standartService;

        public StandartsController(StandartService standartService) 
        {
            _standartService = standartService;
        }

        [HttpGet]
        public IEnumerable<Standart> GetAll()
        {
            return _standartService.GetAll();
        }

        /// <summary>
        /// Получение стандарта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор стандарта</param>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "id" : 1, 
        ///        "name" : "A4Tech Bloody B188",
        ///        "price" : 111,
        ///        "Type": "PeripheryAndAccessories"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="404">Стандарт не найден</response>
        [MapToApiVersion(1)]
        [ProducesResponseType(typeof(Standart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _standartService.Get(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
