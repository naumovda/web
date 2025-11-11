namespace ConsoleApp2.Models
{
    public class MakeupType
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;
    }
}
