namespace ConsoleApp2.Models
{
    public class PVB : Layer
    {
        public PVBType? PVBType { get; set; }

        public int PVBTypeId { get; set; }

        public override string Configuration()
        {
            return PVBType == null ? "" : PVBType.Name;
        }
    }
}
