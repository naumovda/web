namespace ExampleWebAPI01.Models
{
    public class Project
    {
        public int Id { get; set; }

        public Guid UserId { get; set; } = Guid.Empty;

        public int Code { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ModificationDate { get; set; } = DateTime.Now;

        public Standart? Standart { get; set; }

        public int StandartId { get; set; }

        public AirMass? AirMass { get; set; }

        public int AirMassId { get; set; }

        public Illuminant? Illuminant { get; set; }

        public int IlluminantId { get; set; }

        public Observer? Observer { get; set; }

        public int ObserverId { get; set; }

        public List<Makeup> Makeups { get; set; } = [];
    }
}
