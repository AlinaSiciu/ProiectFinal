namespace ProiectFinal.Models
{
    public enum NivelCal
    {
        Incepator,
        Intermediar,
        Avansat
    }
    public class Cal
    {
        public int ID { get; set; }
        public string NumeCal { get; set; }
        public int AnulNasterii { get; set; }
        public NivelCal Nivel { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<CategorieCal>? CategoriiCai { get; set; }
    }
}
