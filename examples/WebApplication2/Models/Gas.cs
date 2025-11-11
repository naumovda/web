namespace ExampleWebAPI01.Models
{
    public class Gas : Layer
    {
        public GasType? GasType { get; set; }

        public int GasTypeId { get; set; }

        public override string Configuration()
        {
            return GasType == null ? "" : GasType.Name;
        }
    }
}
