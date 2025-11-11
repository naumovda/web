namespace ExampleWebAPI01.Models
{
    public class Parameter
    {
        public int Id {  get; set; }

        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ParameterValue> ParameterValues { get; set; } = new List<ParameterValue>();
    }
}
