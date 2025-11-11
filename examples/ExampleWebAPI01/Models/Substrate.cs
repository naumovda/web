namespace ExampleWebAPI01.Models
{
    public class Substrate : Layer
    {
        public SubstrateType? SubstrateType { get; set; }

        public Coating? InnerCoating { get; set; }
        
        public Coating? OuterCoating { get; set; }

        public int SubstrateTypeId { get; set; }

        public override string Configuration()
        {
            return SubstrateType == null ? "" : SubstrateType.Name;
        }
    }
}
