namespace ExampleWebAPI01.Models
{
    public class MakeupWarning
    {
        public int Id { get; set; }

        public int WarningTypeId { get; set; }
        
        public WarningType? WarningType { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
