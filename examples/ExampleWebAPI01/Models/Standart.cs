using System.ComponentModel.DataAnnotations;

namespace ExampleWebAPI01.Models
{
    /// <summary>
    /// Стандарт
    /// </summary>
    public class Standart
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Наименование обязательно")]
        public string Name { get; set; } = string.Empty;
    }
}
