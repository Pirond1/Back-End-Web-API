namespace TrabalhoBiblioteca.Model
{
    public class LivroModel
    {
        public int id { get; set; }
        public string titulo { get; set; } = String.Empty;
        public string autor { get; set; } = String.Empty;
        public int isbn { get; set; }
        public int anoPublicacao { get; set; }
    }
}
