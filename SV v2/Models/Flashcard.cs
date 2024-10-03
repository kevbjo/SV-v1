namespace SV_v2.Models
{
    public class Flashcard
    {
        public int Id { get; set; } // Unikt ID för varje kort
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
