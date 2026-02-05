using System.ComponentModel.DataAnnotations;

namespace BookStore.DTO.Livros
{
    public class LivroRequest
    {
        [Required(ErrorMessage = "O título do livro é obrigatório.")]        
        public string Titulo { get; set; } = string.Empty;
        public string? Autor { get; set; }

        [Required(ErrorMessage = "O ISBN do livro é obrigatório.")]
        [MaxLength(13, ErrorMessage = "Tamanho Maximo de 13 caracteres sem hifen")]       
        public string Isbn { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ano de publicação do livro é obrigatório.")]
        public DateTime AnoPublicacao { get; set; }

        [Required(ErrorMessage = "A editora do livro é obrigatória.")]
        public string Editora { get; set; } = string.Empty;

        [Required(ErrorMessage = "O status do livro é obrigatório.")]

        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = " A data de Cadastro do Livro, é obrigatória")]
        public DateTime DataCadastro { get; set; }

    }
}
