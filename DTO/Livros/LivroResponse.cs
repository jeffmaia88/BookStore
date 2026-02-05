namespace BookStore.DTO.Livros
{
    public class LivroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Autor { get; set; }
        public string Isbn { get; set; } = string.Empty;
        public DateTime AnoPublicacao { get; set; }
        public string Editora { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }


    }
}
