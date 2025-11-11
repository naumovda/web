using Microsoft.EntityFrameworkCore;

namespace ExampleWebAPI01.Models
{
    public class ApplicationContext : DbContext
    {
        public List<Standart> Standarts { get; set; }
        public List<AirMass> AirMasses { get; set; }
        public List<Illuminant> Illuminants{ get; set; }
        public List<Observer> Observers { get; set; }
        public List<CalculationState> CalculationStates { get; set; }
        public List<MakeupType> MakeupTypes { get; set; }
        public List<WarningType> WarningTypes { get; set; }

        public List<Project> Projects { get; set; }
        public List<Makeup> Makeups { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Coating> Coatings { get; set; }
        public List<Substrate> Substrates { get; set; }
        public List<Gas> Gas { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Web2415-021;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var gost = new Standart { Id = 1, Code = 1, Name = "ГОСТ" };

            modelBuilder.Entity<Standart>().HasData(
                gost,
                new Standart { Id = 2, Code = 2, Name = "EN" },
                new Standart { Id = 3, Code = 3, Name = "NFRC" });

            modelBuilder.Entity<AirMass>().HasData(                
                new AirMass { Id = 1, Code = 1, Name = "1.0 EN 410" });

            modelBuilder.Entity<Illuminant>().HasData(
                new AirMass { Id = 1, Code = 1, Name = "A" },
                new AirMass { Id = 2, Code = 2, Name = "C" },
                new AirMass { Id = 3, Code = 3, Name = "D65" }
                );

            modelBuilder.Entity<Observer>().HasData(
                new AirMass { Id = 1, Code = 1, Name = "2 градуса" },
                new AirMass { Id = 2, Code = 2, Name = "10 градусов" },
                new AirMass { Id = 3, Code = 3, Name = "Сумеречный вид" });

            modelBuilder.Entity<CalculationState>().HasData(
                new AirMass { Id = 1, Code = 1, Name = "Calculated" },
                new AirMass { Id = 2, Code = 2, Name = "Has warnings" },
                new AirMass { Id = 3, Code = 3, Name = "Has errors" });

            modelBuilder.Entity<MakeupType>().HasData(
                new MakeupType { Id = 1, Code = 1, Name = "Mono", ShortName = "Mono", Icon = "mono.png" },
                new MakeupType { Id = 2, Code = 2, Name = "Double", ShortName = "DBU", Icon = "double.png" },
                new MakeupType { Id = 3, Code = 3, Name = "Triple", ShortName = "TBU", Icon = "tripe.png" });

            modelBuilder.Entity<WarningType>().HasData(
                new WarningType { Id = 1, Code = 1, Name = "Error" },
                new WarningType {Id = 2, Code = 2, Name = "Warning" });

            modelBuilder.Entity<LayerType>().HasData(
                new LayerType { Id = 1, Code = 1, Name = "Substrate" },
                new LayerType { Id = 2, Code = 2, Name = "AirGap" }, 
                new LayerType { Id = 3, Code = 3, Name = "PVB" });

            modelBuilder.Entity<CoatingSurface>().HasData(
                new CoatingSurface { Id = 1, Code = 1, Name = "Inner" },
                new CoatingSurface { Id = 2, Code = 2, Name = "Outer" });

            modelBuilder.Entity<CoatingType>().HasData(
                new CoatingType { Id = 1, Code = 1, Name = "Film" },
                new CoatingType { Id = 2, Code = 2, Name = "Frit" });

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Code = 1, Name = "Test project 01", StandartId = 1, AirMassId = 1, IlluminantId = 1, ObserverId = 1,
                    CreationDate = DateTime.Parse("2025-10-03"), ModificationDate = DateTime.Parse("2025-10-03")});

            modelBuilder.Entity<ParameterValue>()
                .HasKey(x => new {x.ParameterId, x.MakeupId } );
            
            modelBuilder.Entity<Substrate>().ToTable("Substrate");
            modelBuilder.Entity<Gas>().ToTable("Gas");
            modelBuilder.Entity<PVB>().ToTable("PVB");

            modelBuilder.Entity<Coating>().UseTpcMappingStrategy();
        }
    }
}
