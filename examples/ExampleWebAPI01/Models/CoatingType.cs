namespace ExampleWebAPI01.Models
{
    /// <summary>
    /// Тип поверхности покрытия
    /// </summary>
    public enum CoatingSurfaceEnum
    {
        /// <summary>
        /// Внутреннее покрытие
        /// </summary>
        Inner = 0,

        /// <summary>
        /// Внешнее покрытие
        /// </summary>
        Outer = 1
    }

    public class CoatingType
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
