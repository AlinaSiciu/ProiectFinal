namespace ProiectFinal.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieCal>? CategoriiCal { get; set; }
    }
}
