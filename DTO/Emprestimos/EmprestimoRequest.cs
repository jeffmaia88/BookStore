using System.ComponentModel.DataAnnotations;

namespace BookStore.DTO.Emprestimos
{
    public class EmprestimoRequest
    {
        [Required(ErrorMessage = "A data de devolução prevista é obrigatória.")]
        public DateTime DataDevolucaoPrevista { get; set; }

        public List<int> LivrosIds { get; set; } = new();
    }
}
