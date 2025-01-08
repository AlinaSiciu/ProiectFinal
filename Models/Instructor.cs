namespace ProiectFinal.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string? FullName
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Cal>? Cai { get; set; }
    }
}
