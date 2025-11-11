namespace ExampleWebAPI01.Models
{
    public class Makeup
    {
        public int Id { get; set; }         
        public int Code { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Slope { get; set; } = 90;
        public double Width { get; set; } = 0;
        public double NominalWeight { get; set; } = 0;
        public string SoundReduction { get; set; } = "";
        
        public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public MakeupType? MakeupType { get; set; }
        public int MakeupTypeId { get; set; }

        public int CalculationStateId { get; set; }        
        public CalculationState? CalculationState { get; set; }

        public List<MakeupWarning> Warnings { get; set; } = [];

        public List<ParameterValue> ParameterValues { get; set; } = [];

        public List<Layer> Layers { get; set; } = [];
    }
}
