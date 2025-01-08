namespace ProiectFinal.Models
{
    public class CategorieCal
    {
        public int ID { get; set; }
        public int CalID { get; set; }
        public Cal Cal { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }

    }
}
