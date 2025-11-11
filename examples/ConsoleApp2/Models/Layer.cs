namespace ConsoleApp2.Models
{
    public class Layer
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public double Length { get; set; } = 0;

        public LayerType? LayerType { get; protected set; }
        
        public int LayerTypeId { get; protected set; }

        public int MakeupId { get; set; }

        public virtual string Configuration()
        {
            throw new NotImplementedException();
        }
    }
}
