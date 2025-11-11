namespace ExampleWebAPI01.Models
{
    public class Coating
    {
        public int Id { get; set; }

        public CoatingType? CoatingType { get; set; }

        public CoatingSurface? CoatingSurface { get; set; }
    }

    public class CoatingFrit : Coating
    {
        public FritColor? FritColor { get; set; } = null;

        public FritPattern? FritPattern { get; set; } = null;
    }

    public class CoatingFilm : Coating
    {
        public CoatingFilmType? CoatingFilmType { get; set; } = null;
    }
}
